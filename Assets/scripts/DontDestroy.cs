using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    [SerializeField] float fadeTime;
    AudioSource myAS;
    void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("BGMusic");
        foreach (GameObject go in objs) {
            if (go != gameObject)
                if (go.name == gameObject.name)
                    Destroy (gameObject);
                else
                    Destroy (go);
        }
        myAS=GetComponent<AudioSource>();
        DontDestroyOnLoad (gameObject);
        StartCoroutine(FadeTo(1,fadeTime));
    }

    IEnumerator FadeTo (float aValue, float aTime) {
        float alpha = myAS.volume;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            myAS.volume = Mathf.Lerp (alpha, aValue, t);
            yield return null;
        }
    }

    public void FadeOut(){
        StartCoroutine(FadeTo(0,fadeTime));
    }
}