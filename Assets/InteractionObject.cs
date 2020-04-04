using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

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

    public void OnPlayerAction() {
        Debug.Log("JEBAĆ");
        Destroy(this.gameObject);
    }
}
