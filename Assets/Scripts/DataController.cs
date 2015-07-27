using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataController : MonoBehaviour {

	public float animationTime = 20f;

	public GameObject water;
	public Vector3 waterFinalPos;
	public Text nameTxt;
	public Text volumeArmazenadoTxt;
	public Text pluviometriaDoDiaTxt;
	public Text pluviometriaAcuMesTxt;
	public Text mediaHistMesTxt;

	// Use this for initialization
	void Start () {
		nameTxt.text = AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].Name;
		AnimateWater(AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].VolumeArmazenado/100, animationTime);
		StartCoroutine(AnimateVolumeArmazenadoTxt(AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].VolumeArmazenado/100, animationTime));
		StartCoroutine(AnimatePluviometriaDiaTxt(AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].PluviometriaDoDia, animationTime));
		StartCoroutine(AnimatepluviometriaAcuMesTxt(AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].PluviometriaAcuMes, animationTime));
		StartCoroutine(AnimatemediaHistMesTxt(AppDataManager.instance.dataModels[AppDataManager.instance.currentModel].MediHistMes, animationTime));
	}

	IEnumerator AnimateVolumeArmazenadoTxt(float value, float time) {
		float i = 0;
		float rate = 1 / time;
		float temp = 0;
		while(i < 1) {
			i += Time.deltaTime * rate;
			temp = Mathf.Lerp(temp, value, i);
			volumeArmazenadoTxt.text = "Volume Armazenado: "+Mathf.RoundToInt(temp * 100)+"%";
			yield return null;
		}
	}

	IEnumerator AnimatePluviometriaDiaTxt(float value, float time) {
		float i = 0;
		float rate = 1 / time;
		float temp = 0;
		while(i < 1) {
			i += Time.deltaTime * rate;
			temp = Mathf.Lerp(temp, value, i);
			pluviometriaDoDiaTxt.text = "Pluviometria do dia: "+Mathf.RoundToInt(temp)+"mm";
			yield return null;
		}
	}

	IEnumerator AnimatepluviometriaAcuMesTxt(float value, float time) {
		float i = 0;
		float rate = 1 / time;
		float temp = 0;
		while(i < 1) {
			i += Time.deltaTime * rate;
			temp = Mathf.Lerp(temp, value, i);
			pluviometriaAcuMesTxt.text = "Pluv. Acumulada Mes: "+Mathf.RoundToInt(temp)+"mm";
			yield return null;
		}
	}

	IEnumerator AnimatemediaHistMesTxt(float value, float time) {
		float i = 0;
		float rate = 1 / time;
		float temp = 0;
		while(i < 1) {
			i += Time.deltaTime * rate;
			temp = Mathf.Lerp(temp, value, i);
			mediaHistMesTxt.text = "PMedia Historica Mes: "+Mathf.RoundToInt(temp)+"mm";
			yield return null;
		}
	}

	private void AnimateWater(float percentage, float time){
		Vector3 newPos = new Vector3(waterFinalPos.x, waterFinalPos.y * percentage, waterFinalPos.z);
		StartCoroutine(AnimateWaterCoroutine(percentage, time, newPos));
	}

	IEnumerator AnimateWaterCoroutine(float percentage, float time, Vector3 newPosition) {
		float i = 0;
		float rate = 1 / time;
		while(i < 1) {
			i += Time.deltaTime * rate;
			water.transform.position = Vector3.Lerp(water.transform.position, newPosition, i);
			yield return null;
		}
	}
	

}
