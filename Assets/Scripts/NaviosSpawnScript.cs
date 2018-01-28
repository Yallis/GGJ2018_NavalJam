using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviosSpawnScript : MonoBehaviour {

	public GameObject[] prefabs;
	public static List<GameObject> naviosLista = new List <GameObject> ();

	float[] vels = { 0.5f, 1f, 1.5f };
	public static float vel = 1;
	int tipo;

	void Awake(){
		//SpawnNavio ();
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnNavio (){
		tipo = Random.Range(0, vels.Length);
		vel = vels[tipo];

		GameObject tempNavio = Instantiate (prefabs[tipo], transform.position, transform.rotation) as GameObject;
		naviosLista.Add (tempNavio);
		//Debug.Log ("Spawnado: " + naviosLista.Count);
	}
}
