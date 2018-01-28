using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class targetScript : MonoBehaviour {

	public GameObject obsPrefab;

	public List<GameObject> obsLista;

	// Use this for initialization
	void Start () {
		StartCoroutine (RandomPosition());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RandomPosition (){
		int nObs = Random.Range (1, 4);
		Vector2[] positions = new Vector2[5];

		for(int i=0; i<=nObs; i++){
			int x = (int) Random.Range (-6, 6);
			int y = (int) Random.Range (-3, 3);

			while(ArrayUtility.Contains(positions, new Vector2(x, y))){
				x = (int) Random.Range (-6, 6);
				y = (int) Random.Range (-3, 3);
				yield return null;
			}
				
			if (i == nObs) {
				Vector2 targetPosition = new Vector2 (x, y);
				positions [i] = targetPosition;
				transform.position = targetPosition;
				obsLista.Add (gameObject);
			} else {
				Vector2 obsPosition = new Vector2 (x, y);
				positions [i] = obsPosition;
				GameObject tempObs =  Instantiate (obsPrefab, obsPosition, transform.rotation) as GameObject;
				obsLista.Add (tempObs);
			}
		}
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
		GameControlerScript.pontos++;
	}
}