using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameScript : MonoBehaviour {

    bool quitting;

    private void Start()
    {
        quitting = false;
    }

    public void QuitGame(bool touch)
    {
        //Debug.Log("Quitting");
        quitting = touch;
        if(quitting)
            Application.Quit();
    }
}
