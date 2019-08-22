using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour {

    public GameObject interactIcon;

    //Enable object if in range
    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log ("Hit Object");
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive(true);
        }
    }

    //Disable if exit 
    void OnTriggerExit2D (Collider2D col) {
        Debug.Log ("Exit Object");
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}