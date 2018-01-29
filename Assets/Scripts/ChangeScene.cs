using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	void Start(){
		Time.timeScale = 1;
	}
    public void NextScene(string name)
    {
		Time.timeScale = 1;
		//if(name == "mainTitle")
        //SceneManager.LoadScene(name, LoadSceneMode.Single);
        Initiate.Fade(name, Color.black, 1f);
    }
}
