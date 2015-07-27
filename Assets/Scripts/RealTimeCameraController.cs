using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealTimeCameraController : MonoBehaviour {

	public GameObject screen;

	private bool activated = false;
	private int counter = 0;
	private float timer = 0;
	private float timer2 = 0;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		if(timer >= 1) {
			timer = 0;
			counter++;
		}

		if(timer2 >= .5f){
			timer2 = 0;
			if(activated){
				StartCoroutine(LoadWebData());
			}
		}

	}

	IEnumerator LoadWebData() {
		WWW www = new WWW(AppDataManager.instance.externalAdress+"cam_pic.php?time="+counter+"&pDelay=1000");
		yield return www;
		screen.GetComponent<Renderer>().material.mainTexture = www.texture;
	}

	public void RealTimeBtnOnClick() {
		if(activated){
			screen.SetActive(false);
			activated = false;
		}else{
			activated = true;
			screen.SetActive(true);
		}
	}

}
