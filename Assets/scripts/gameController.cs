using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
    SonMovement sm;
    MotherMovement mm;
    public bool interaction = false;
    private void Start () {
        Init (SceneManager.GetActiveScene (), SceneManager.GetActiveScene ());
        SceneManager.activeSceneChanged += Init;
    }

    private void Init (Scene current, Scene next) {
        sm = FindObjectOfType<SonMovement> ();
        mm = FindObjectOfType<MotherMovement> ();
        sm?.fadeIn ();
        mm?.fadeIn ();
        interaction = false;
    }

    public void LoadScene () {
        sm?.fadeOut ();
        mm?.fadeOut ();
    }

}