using UnityEngine;
using SimpleJSON;
using System.Collections;

public class LoadController : MonoBehaviour {



	// Use this for initialization
	void Start () {

		TextAsset txt = Resources.Load("Addresses") as TextAsset;
		AppDataManager.instance.externalAdress = txt.text;

		StartCoroutine(LoadWebData());
	}

	IEnumerator LoadWebData() {
		WWW www = new WWW(AppDataManager.instance.externalAdress+"dados/output.json");
		yield return www;
		//Read JSON data
		LoadDataFromJson(www.text);
	}

	private void LoadDataFromJson(string json) {
		JSONNode rootNode = JSON.Parse(json);
		for (int i = 0; i < rootNode.Count; i++) {
			DataModel dm = new DataModel();
			dm.Name = rootNode[i]["name"];
			for (int j = 0; j < rootNode[i][0].Count; j++) {
				switch (j) {
				case 0:
					dm.VolumeArmazenado = rootNode[i][0][j].AsFloat;
				break;
				case 1:
					dm.PluviometriaDoDia = rootNode[i][0][j].AsFloat;
					break;
				case 2:
					dm.PluviometriaAcuMes = rootNode[i][0][j].AsFloat;
					break;
				case 3:
					dm.MediHistMes = rootNode[i][0][j].AsFloat;
					break;
				}
			}
			AppDataManager.instance.dataModels.Add(dm);
		}

		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel() {
		AsyncOperation async = Application.LoadLevelAsync(1);
		yield return async;
	}

}
