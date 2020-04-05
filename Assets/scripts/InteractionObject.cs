using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Actor {
    SON,
    MOTHER
}

[Serializable]
public class dS {
    public string dialogName;
    public float dialogStartEventDelay;
    public UnityEvent EventDialogStart;
    public float dialogEndedEventDelay;
    public UnityEvent EventDialogEnded;
}

[RequireComponent (typeof (BoxCollider2D))]
public class InteractionObject : MonoBehaviour {
    [SerializeField] dS[] dialogSequenceSon;
    [SerializeField] dS[] dialogSequenceMother;
    [SerializeField] UnityEvent SonEvent;
    [SerializeField] UnityEvent MotherEvent;
    dS[] triggeredDialog;
    [SerializeField] bool MatkaInter = true, SynInter = true;
    DialogueSystemFromHell dsfh;
    int mL = 0, sL = 0;
    void Start () {
        mL = MatkaInter?9 : 0;
        sL = SynInter?8 : 0;
        dsfh = FindObjectOfType<DialogueSystemFromHell> ();
    }

    public void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL || col.gameObject.layer == sL)) {
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (true);
            col.gameObject.SendMessage ("SetInteractionObject", this);
        }
    }
    public void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL || col.gameObject.layer == sL)) {
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (false);
            col.gameObject.SendMessage ("ClearInteractionObject");
        }
    }

    int i = 0;
    void dialog () {
        dsfh.startDialogue (triggeredDialog[i].dialogName);
        StartCoroutine(startEventWithDelay(triggeredDialog[i].EventDialogStart,triggeredDialog[i].dialogStartEventDelay));
        dsfh.DialogueEndedEvent += nexDialog;
    }

    IEnumerator startEventWithDelay(UnityEvent ue, float time){
        yield return new WaitForSeconds(time);
        ue.Invoke();
    }
    private void nexDialog () {
        StartCoroutine(startEventWithDelay(triggeredDialog[i].EventDialogEnded,triggeredDialog[i].dialogEndedEventDelay));
        i++;
        if (i < triggeredDialog.Length) {
            dsfh.startDialogue (triggeredDialog[i].dialogName);
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