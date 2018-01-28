using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviosScript : MonoBehaviour {

	public GameObject[] prefabs;
	public AudioClip sound;
	AudioSource source;

	Vector2 dir;

	float ang;
	float angulo;
	float vel;
	float currentVel;
	//float[] vels = { 0.5f, 1f, 1.5f };
	//int tipo;

	//Color[] cores = { Color.red, Color.blue, Color.yellow, Color.green };
	public int tipoCor;
	bool explodiu = false;

	Rigidbody2D rb;
	Animator Anime;
	Collider2D col;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Anime = GetComponent<Animator> ();
		col = GetComponent<PolygonCollider2D> ();

		gameObject.AddComponent<AudioSource> ();
		source = GetComponent<AudioSource> ();

		source.clip = sound;
		source.playOnAwake = false;

		ang = transform.eulerAngles.z;
		angulo = ang;

		//tipo = Random.Range(0, vels.Length);
		//vel = vels[tipo];

		tipoCor = Random.Range(1, 5);
		Anime.SetInteger ("Cor", tipoCor-1);
		//sr.color = cores [tipoCor-1];

		vel = NaviosSpawnScript.vel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!explodiu) {
			angulo = Mathf.Lerp (angulo, ang, 0.05f);
			//Debug.Log (angulo);
			transform.rotation = Quaternion.Euler (0, 0, angulo);
			dir = transform.rotation * Vector2.up;

			if (Mathf.Round (angulo) == Mathf.Round (ang)) {
				currentVel = vel;
			} else
				currentVel = vel * 0.75f;
			//rb.velocity = new Vector2 (dir.x * currentVel, dir.y * currentVel);
		} else {
			Anime.SetBool ("Explodiu", explodiu);
			col.enabled = false;
			currentVel = 0;
		}
		rb.velocity = new Vector2 (dir.x * currentVel, dir.y * currentVel);
	}


	public void Girar (int d){
		//Debug.Log ("tipo: " + tipoCor);
		if (Mathf.Abs(d) == tipoCor){
			if (d > 0)
				ang += 90;
			else
				ang -= 90;
		}
	}

	void DestroiNavio (){
		NaviosSpawnScript.naviosLista.Remove (gameObject);
		PlaySound ();											// Som explosão
		//Debug.Log (NaviosSpawnScript.naviosLista.Count);
		Destroy (gameObject);
	}

	IEnumerator DestroiNavio (float t){
		NaviosSpawnScript.naviosLista.Remove (gameObject);
		PlaySound ();
		//Debug.Log (NaviosSpawnScript.naviosLista.Count);
		yield return new WaitForSeconds (t);
		Destroy (gameObject);
	}

	void PlaySound(){
		source.PlayOneShot (sound);
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log ("Barco destruido");
		if (col.tag == "Target")
			DestroiNavio ();
		else if(col.tag != "Sinal"){
			explodiu = true;
			StartCoroutine (DestroiNavio (0.5f));
		}
	}

	void OnBecameInvisible(){
		//Debug.Log ("Barco destruido");
		DestroiNavio ();
	}
}
