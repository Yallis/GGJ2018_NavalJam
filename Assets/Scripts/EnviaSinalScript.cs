using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviaSinalScript : MonoBehaviour {

	public AudioClip sound;
	AudioSource source;

	public GameObject sinalPrefab;
	public float sinalVel = 1;

	Color[] cores = { Color.red, Color.yellow, Color.green, Color.magenta };

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();
		source = GetComponent<AudioSource> ();

		source.clip = sound;
		source.playOnAwake = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void PlaySound(){
		source.PlayOneShot (sound);
	}

	public void EnviaSinal (int n){
		for(int i=0; i<NaviosSpawnScript.naviosLista.Count; i++){
			if (NaviosSpawnScript.naviosLista [i].GetComponent<NaviosScript> ().tipoCor == n) {
				Vector2 difference = NaviosSpawnScript.naviosLista [i].transform.position - transform.position;
				Vector2 sinalDir = difference.normalized;

				float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler (0f, 0f, rotZ - 90);

				GameObject tempSinal = Instantiate (sinalPrefab, transform.position, transform.rotation) as GameObject;
				tempSinal.GetComponent<SpriteRenderer> ().color = cores [n-1];

				tempSinal.GetComponent<Rigidbody2D> ().velocity = new Vector2 (sinalDir.x * sinalVel, sinalDir.y * sinalVel);
			}
		}
		PlaySound ();
	}
}
