using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    [SerializeField] float fadeTime;
    Image mySR;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<Image>();
        StartCoroutine(FadeTo(0,fadeTime));
    }

    // Update is called once per frame
    public void FadeOut(){
        StartCoroutine(FadeTo(1,fadeTime));
    }

    IEnumerator FadeTo (float aValue, float aTime) {
        float alpha = mySR.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color (0, 0, 0, Mathf.Lerp (alpha, aValue, t));
            mySR.color = newColor;
            yield return null;
        }
    }
}
