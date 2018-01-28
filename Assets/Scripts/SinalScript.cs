using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Navio")
			Destroy (gameObject);
	}*/

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
