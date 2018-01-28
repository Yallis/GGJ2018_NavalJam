using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public void NextScene(string name)
    {
        //SceneManager.LoadScene(name, LoadSceneMode.Single);
        Initiate.Fade(name, Color.black, 1f);
    }
}
