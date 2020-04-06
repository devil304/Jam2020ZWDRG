using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public enum Actor {
    SON,
    MOTHER,
    Both
}

[Serializable]
public class dS {
    public string dialogName;
    public float dialogStartEventDelay;
    public UnityEvent EventDialogStart;
    public float dialogEndedEventDelay;
    public UnityEvent EventDialogEnded;
}

[Serializable]
public class UnityEventActor : UnityEvent<Actor>
{

}

[RequireComponent (typeof (BoxCollider2D))]
public class InteractionObject : MonoBehaviour {
    [SerializeField] dS[] dialogSequenceSon;
    [SerializeField] dS[] dialogSequenceMother;
    [SerializeField] UnityEventActor SonEvent;
    [SerializeField] UnityEventActor MotherEvent;
    dS[] triggeredDialog;
    [SerializeField] bool MatkaInter = true, SynInter = true, persist = false;
    DialogueSystemFromHell dsfh;
    gameController gc;
    public Transform interPlayer;
    int mL = 0, sL = 0;
    [SerializeField] float cooldown = 0;
    void Start () {
        gc = FindObjectOfType<gameController>();
        mL = MatkaInter?9 : 0;
        sL = SynInter?8 : 0;
        dsfh = FindObjectOfType<DialogueSystemFromHell> ();
    }

    private void OnDisable()
    {
        if (persist && GetComponent<PushPull>())
        {
            interPlayer.gameObject.SendMessage("ClearInteractionObject", this);
            GetComponent<PushPull>().pushPull(Actor.Both);
        }
    }

    public void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL || col.gameObject.layer == sL)) {
            interPlayer = col.transform;
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (true);
            col.gameObject.SendMessage ("SetInteractionObject", this);
        }
    }
    public void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Player" && (col.gameObject.layer == mL || col.gameObject.layer == sL)) {
            interPlayer = null;
            if (transform.childCount > 0)
                transform.GetChild (0).gameObject.SetActive (false);
            col.gameObject.SendMessage ("ClearInteractionObject", this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(persist && collision.tag == "Player")
            collision.gameObject.SendMessage("SetInteractionObject", this);
    }

    int i = 0;
    void dialog () {
        dsfh.startDialogue (triggeredDialog[i].dialogName);
        StartCoroutine (startEventWithDelay (triggeredDialog[i].EventDialogStart, triggeredDialog[i].dialogStartEventDelay));
        dsfh.DialogueEndedEvent += nexDialog;
    }

    IEnumerator startEventWithDelay (UnityEvent ue, float time) {
        yield return new WaitForSeconds (time);
        ue.Invoke ();
    }
    private void nexDialog () {
        StartCoroutine (startEventWithDelay (triggeredDialog[i].EventDialogEnded, triggeredDialog[i].dialogEndedEventDelay));
        i++;
        if (i < triggeredDialog.Length) {
            dsfh.startDialogue (triggeredDialog[i].dialogName);
        } else {
            i = 0;
            dsfh.DialogueEndedEvent -= nexDialog;
            gc.interaction = false;
        }
    }

    public void OnPlayerAction (Actor type) {
        if (!gc.interaction) {
            gc.interaction = true;
            switch (type) {
                case Actor.SON:
                    if (dialogSequenceSon.Length > 0)
                    {
                        triggeredDialog = dialogSequenceSon;
                        i = 0;
                        dialog();
                    }
                    else
                        StartCoroutine(cd());
                    SonEvent.Invoke (type);
                    break;
                case Actor.MOTHER:
                    if (dialogSequenceMother.Length > 0) {
                        triggeredDialog = dialogSequenceMother;
                        i = 0;
                        dialog ();
                    }else
                        StartCoroutine(cd());
                    MotherEvent.Invoke (type);
                    break;
            }
        }
    }
    IEnumerator cd()
    {
        yield return new WaitForSeconds(cooldown);
        gc.interaction = false;
    }
}