using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Actor {
    SON,
    MOTHER
}

public class InteractionObject : MonoBehaviour {
    [SerializeField] string[] dialogSequenceSon;
    [SerializeField] string[] dialogSequenceMother;
    [SerializeField] UnityEvent SonEvent;
    [SerializeField] UnityEvent MotherEvent;
    string[] triggeredDialog;
    [SerializeField] bool MatkaInter = true, SynInter = true;
    DialogueSystemFromHell dsfh;
    int mL = 0, sL = 0;
    void Start () {
        mL=MatkaInter?9:0;
        sL=SynInter?8:0;
        dsfh = FindObjectOfType<DialogueSystemFromHell> ();
    }

    public void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL|| col.gameObject.layer == sL)) {
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (true);
            col.gameObject.SendMessage ("SetInteractionObject", this);
        }
    }
    public void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL|| col.gameObject.layer == sL)) {
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (false);
            col.gameObject.SendMessage ("ClearInteractionObject");
        }
    }

    int i = 0;
    void dialog () {

        dsfh.startDialogue (triggeredDialog[i]);
        i++;
        dsfh.DialogueEndedEvent += nexDialog;
    }

    private void nexDialog () {
        if (i < triggeredDialog.Length) {
            dsfh.startDialogue (triggeredDialog[i]);
            i++;
        } else {
            i = 0;
            dsfh.DialogueEndedEvent -= nexDialog;
        }
    }

    public void OnPlayerAction (Actor type) {
        switch (type) {
            case Actor.SON:
                if (dialogSequenceSon.Length > 0) {
                    triggeredDialog = dialogSequenceSon;
                    i = 0;
                    dialog ();
                }
                SonEvent.Invoke ();
                break;
            case Actor.MOTHER:
                if (dialogSequenceMother.Length > 0) {
                    triggeredDialog = dialogSequenceMother;
                    i = 0;
                    dialog ();
                }
                MotherEvent.Invoke ();
                break;
        }
    }
}