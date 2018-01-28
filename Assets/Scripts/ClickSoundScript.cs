using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSoundScript : MonoBehaviour {

	public AudioClip sound;
	Button button;
	AudioSource source;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();

		button = GetComponent<Button> ();
		source = GetComponent<AudioSource> ();

		source.clip = sound;
		source.playOnAwake = false;

		button.onClick.AddListener (() => PlaySound());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaySound(){
		source.PlayOneShot (sound);
	}
}
