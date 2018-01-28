using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlerScript : MonoBehaviour {

	//NaviosScript scriptNavios;
	//targetScript scriptTarget;

	public static int pontos;
	public static bool timeOut = false; // Variavle fim do tempo
	public static bool pause = false;

	public Text txtPotos;
	public Text	txtTempo;

	public int numeroNavios = 4;
	public GameObject targetGO;
	//public GameObject prefab;
	public List<GameObject> spawnPoints;

	//public static List<GameObject> naviosLista = new List <GameObject> ();

	float timeLevel = 60;
	float currentTimeLevel;
	float tempo;
	float currentTempo;

	int[] spawnPointsRandomList;
	int spawnPointRandom;
	int[] previusSpawnPoints = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

	float spawnRate = 3.5f;
	float currentSpawnRate;

	int nObjetivo = 4;
	int nLevel = 1;

	// Use this for initialization
	void Start () {
		currentSpawnRate = Time.time;
		Time.timeScale = 1.0f;

		currentTimeLevel = timeLevel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > currentSpawnRate){
			StartCoroutine( SetSpawn ());
			currentSpawnRate = Time.time + spawnRate;
		}

		if(pontos == nObjetivo){
			currentTimeLevel = timeLevel;
			nLevel++;
			nObjetivo = nLevel * 2 + 2;
			pontos = 0;
			//SceneManager.LoadScene ("Cena");
			targetScript scriptTarget = targetGO.GetComponent<targetScript> ();
			scriptTarget.ResetLevel ();
		}

		if (currentTimeLevel == 0) {
			//currentTimeLevel = timeLevel;
			timeOut = true;
		}
		else if (Time.time > currentTempo + 1) {
			currentTimeLevel--;
			currentTempo = Time.time;
		}

		if(timeOut || pause){
			Time.timeScale = 0.0f;
		}

		txtPotos.text = pontos.ToString() + "/" + nObjetivo.ToString();
		txtTempo.text = currentTimeLevel.ToString ();
	}

	IEnumerator SetSpawn (){
		int nNavios = Random.Range (2, 5);
		int count = 0;

		for (int i = 0; i < nNavios; i++) {
			spawnPointRandom = Random.Range (0, spawnPoints.Count - 1);

			while (spawnPoints [spawnPointRandom].activeSelf || previusSpawnPoints [spawnPointRandom] > 0) {
				if (count == nNavios)
					break;
				spawnPointRandom = Random.Range (0, spawnPoints.Count - 1);
				yield return null;
			}

			spawnPoints [spawnPointRandom].SetActive (true);
			NaviosSpawnScript scriptNaviosSpawn = spawnPoints [spawnPointRandom].GetComponent<NaviosSpawnScript> ();
			scriptNaviosSpawn.SpawnNavio ();
			count++;
			//GameObject tempNavio = Instantiate (prefab, spawnPoints [spawnPointRandom].transform.position, spawnPoints [spawnPointRandom].transform.rotation) as GameObject;
			//naviosLista.Add (tempNavio);
		}

		for(int i=0; i<spawnPoints.Count; i++){
			if (previusSpawnPoints [i] == 0 && spawnPoints [i].activeSelf){
				previusSpawnPoints [i] = 1;
			}
			else if(previusSpawnPoints [i] > 0){
				previusSpawnPoints [i]--;
			}
		}

		ResetSpawn ();
	}

	public void GirarBarcos (int d){
		foreach (GameObject navio in NaviosSpawnScript.naviosLista) {
			NaviosScript script = navio.GetComponent<NaviosScript> ();
			script.Girar (d);
		}
	}

	void ResetSpawn (){
		for (int i = 0; i < spawnPoints.Count; i++) {
			spawnPoints [i].SetActive (false);
		}
	}
}
