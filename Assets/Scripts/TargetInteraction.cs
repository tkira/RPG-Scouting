using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInteraction : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject targetInteract = null;
    public bool targetedInteract = false;

    GameObject ClickSelect () {
        Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero, Mathf.Infinity);

        if (hit) {
            if (hit.collider.tag == "Interact") {
                Debug.Log ("Hit Interact");
                targetedInteract = true;
                return GameObject.Find (hit.collider.name);
            }
        }
        targetedInteract = false;
        return null;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            targetedInteract = ClickSelect ();
        }
    }
}