using UnityEngine;
using System.Collections;

public class DataModel{

	private string name;

	public string Name {
		get {
			return name;
		}
		set {
			name = value;
		}
	}

	private float volumeArmazenado;

	public float VolumeArmazenado {
		get {
			return volumeArmazenado;
		}
		set {
			volumeArmazenado = value;
		}
	}

	private float pluviometriaDoDia;

	public float PluviometriaDoDia {
		get {
			return pluviometriaDoDia;
		}
		set {
			pluviometriaDoDia = value;
		}
	}

	private float pluviometriaAcuMes;

	public float PluviometriaAcuMes {
		get {
			return pluviometriaAcuMes;
		}
		set {
			pluviometriaAcuMes = value;
		}
	}

	private float mediHistMes;


	public float MediHistMes {
		get {
			return mediHistMes;
		}
		set {
			mediHistMes = value;
		}
	}
}
