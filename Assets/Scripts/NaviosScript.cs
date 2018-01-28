using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviosScript : MonoBehaviour {

	public GameObject[] prefabs;

	Vector2 dir;

	float ang;
	float angulo;
	float vel;
	float currentVel;
	//float[] vels = { 0.5f, 1f, 1.5f };
	//int tipo;

	//Color[] cores = { Color.red, Color.blue, Color.yellow, Color.green };
	int tipoCor;

	Rigidbody2D rb;
	SpriteRenderer sr;
	Animator Anime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		Anime = GetComponent<Animator> ();

		ang = transform.eulerAngles.z;
		angulo = ang;

		//tipo = Random.Range(0, vels.Length);
		//vel = vels[tipo];

		tipoCor = Random.Range(1, 4);
		Anime.SetInteger ("Cor", tipoCor-1);
		//sr.color = cores [tipoCor-1];

		vel = NaviosSpawnScript.vel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		angulo = Mathf.Lerp (angulo, ang, 0.05f);
		//Debug.Log (angulo);
		transform.rotation = Quaternion.Euler (0, 0, angulo);
		dir = transform.rotation * Vector2.up;
		if (Mathf.Round(angulo) == Mathf.Round(ang)) {
			currentVel = vel;
		}
		else
			currentVel = vel * 0.75f;
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

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log ("Barco destruido");
		NaviosSpawnScript.naviosLista.Remove (gameObject);
		Destroy (gameObject);
	}

	void OnBecameInvisible(){
		//Debug.Log ("Barco destruido");
		NaviosSpawnScript.naviosLista.Remove (gameObject);
		Destroy (gameObject);
	}
}
