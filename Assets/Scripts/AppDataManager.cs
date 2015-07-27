using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppDataManager : MonoBehaviour {

	public List<DataModel> dataModels;
	public int currentModel = 0;

	public string externalAdress;

	private static AppDataManager _instance;
	
	public static AppDataManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AppDataManager>();

				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}

	void Awake() 
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if(this != _instance)
				Destroy(this.gameObject);
		}

		dataModels = new List<DataModel>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
