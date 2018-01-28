using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class targetScript : MonoBehaviour {

	public AudioClip sound;
	AudioSource source;

	public GameObject obsPrefab;
	public List<GameObject> obsLista;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();
		source = GetComponent<AudioSource> ();

		source.clip = sound;
		source.playOnAwake = false;

		StartCoroutine (RandomPosition());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaySound(){
		source.PlayOneShot (sound);
	}

	IEnumerator RandomPosition (){
		int nObs = Random.Range (1, 4);
		//Vector2[] positions = new Vector2[5];
		List<Vector2> positions = new List<Vector2> ();

		for(int i=0; i<=nObs; i++){
			int x = (int) Random.Range (-6, 6);
			int y = (int) Random.Range (-3, 3);

			//while( ArrayUtility.Contains(positions, new Vector2(x, y))){
			while(positions.Contains(new Vector2(x, y))){
				x = (int) Random.Range (-6, 6);
				y = (int) Random.Range (-3, 3);
				yield return null;
			}
				
			if (i == nObs) {
				Vector2 targetPosition = new Vector2 (x, y);
				//positions [i] = targetPosition;
				positions.Add(targetPosition);
				transform.position = targetPosition;
				obsLista.Add (gameObject);
			} else {
				Vector2 obsPosition = new Vector2 (x, y);
				//positions [i] = obsPosition;
				positions.Add(obsPosition);
				GameObject tempObs =  Instantiate (obsPrefab, obsPosition, transform.rotation) as GameObject;
				obsLista.Add (tempObs);
			}
		}

		positions.Clear ();
	}

	public void ResetLevel(){
		for(int i=0; i<obsLista.Count-1; i++){
			Destroy (obsLista[i]);
		}
		//foreach(GameObject obs in obsLista){
		//	Destroy (obs);
		//}
		obsLista.Clear();

		StartCoroutine (RandomPosition());
	}

	public void OnTriggerEnter2D (Collider2D col){
		//Debug.Log ("Pontuacao +1");
		PlaySound();
		if(col.tag == "Navio")
			GameControlerScript.pontos++;
	}
}