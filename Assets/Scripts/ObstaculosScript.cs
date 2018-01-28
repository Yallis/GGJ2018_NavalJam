using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosScript : MonoBehaviour {

	//public List<GameObject> obsPrefabs;

	public Sprite[] obsSprites;
	SpriteRenderer sr;
	PolygonCollider2D col;



	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();

		int tipo = Random.Range (0, obsSprites.Length);
		sr.sprite = obsSprites[tipo];

		gameObject.AddComponent<PolygonCollider2D> ();
		col = GetComponent<PolygonCollider2D> ();
		col.isTrigger = true;

		int ang = Random.Range (0, 3) * 90;
		transform.rotation = Quaternion.Euler (0, 0, ang);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
