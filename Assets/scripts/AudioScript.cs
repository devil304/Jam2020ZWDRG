using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioScript : MonoBehaviour
{
    AudioSource myFx;

    private void Awake() {
        myFx = GetComponent<AudioSource>();
    }
    //public AudioClip clickFx;
    //bool playing = false;

    public void ClickSound(AudioClip ac)
    {
        DontDestroyOnLoad(gameObject);
        myFx.PlayOneShot(ac);
        //playing=true;
    }

    private void Update() {
        /*if(playing){
            if(!myFx.isPlaying)
                Destroy(gameObject);
        }*/
    }
}
