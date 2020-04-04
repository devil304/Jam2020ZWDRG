using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class speech {
    public string nameId;
    public string text;
    public float time;
}

public class DialogueSystemFromHell : MonoBehaviour {
    public delegate void DialogueEnded ();
    public event DialogueEnded DialogueEndedEvent;
    TextMeshProUGUI tmp;
    [SerializeField] GameObject dialogueBox;
    string startedDialogueId = "";
    [SerializeField] speech[] dialogue;
    Dictionary<string, speech> dialogueBase;
    [SerializeField] float textTypeWaitTime = 0.05f;

    private void Awake () {
        DontDestroyOnLoad (gameObject);
        tmp = dialogueBox.GetComponentInChildren<TextMeshProUGUI> ();
        dialogueBase = new Dictionary<string, speech> ();
        foreach (speech s in dialogue) {
            dialogueBase.Add (s.nameId, s);
        }
        DontDestroyOnLoad (dialogueBox);
    }
    // Start is called before the first frame update
    public void startDialogue (string id) {
        if (startedDialogueId == "") {
            startedDialogueId = id;
            dialogueBox.SetActive (true);
            tmp.text = dialogueBase[id].text;
            StartCoroutine(StartType());
        }
    }

    float time = 0;
    private void Update () {
        if (startedDialogueId != "") {
            time += Time.deltaTime;
            if (time >= dialogueBase[startedDialogueId].time) {
                time = 0;
                startedDialogueId = "";
                dialogueBox.SetActive (false);
                DialogueEndedEvent.Invoke ();
            }
        }
    }

    IEnumerator StartType () {

        // Force and update of the mesh to get valid information.
        tmp.ForceMeshUpdate ();

        int totalVisibleCharacters = tmp.textInfo.characterCount; // Get # of Visible Character in text object
        int counter = 0;
        int visibleCount = 0;

        while (visibleCount < totalVisibleCharacters) {
            visibleCount = counter % (totalVisibleCharacters + 1);

            tmp.maxVisibleCharacters = visibleCount;
            counter += 1;

            yield return new WaitForSeconds (textTypeWaitTime);
        }

    }
}