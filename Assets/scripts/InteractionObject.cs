using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actor {
    SON,
    MOTHER
}

public class InteractionObject : MonoBehaviour {
    DialogueSystemFromHell dsfh;
    void Start() {
        dsfh = FindObjectOfType<DialogueSystemFromHell>();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            transform.GetChild(0)?.gameObject?.SetActive(true);
            col.gameObject.SendMessage("SetInteractionObject", this);
        }
    }
    public void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            transform.GetChild(0)?.gameObject?.SetActive(false);
            col.gameObject.SendMessage("ClearInteractionObject");
        }
    }

    void DialogAction() {

        dsfh.startDialogue("nazwaDialogu");
        dsfh.DialogueEndedEvent += () => {
            //wykonaj po zakończeniu dialogu, np: odpal kolejny czy coś
        };
    }

    public void OnPlayerAction() {
        Debug.Log("JEBAĆ");
        Destroy(this.gameObject);
    }
}
