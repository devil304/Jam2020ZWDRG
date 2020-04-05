using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
    [SerializeField] GameObject Light = null;
    [SerializeField] AudioClip LightOn = null;
    [SerializeField] AudioClip LightOff = null;
    public AudioSource audioSource = null;
    public float volume = 0.3f;

    public void ToggleLight() {
        PlaySound(!Light.activeInHierarchy);
        Light.SetActive(!Light.activeInHierarchy);
    }

    public void PlaySound(bool onOff) {
        if (onOff && LightOn != null) {
            audioSource.PlayOneShot(LightOn, volume);
        } else if (LightOff != null) {
            audioSource.PlayOneShot(LightOff, volume);
        }
    }

}
