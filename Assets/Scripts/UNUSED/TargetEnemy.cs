using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour {

    public GameObject targetEnemy = null;
    public bool targetedEnemy = false;
    public PlayerDetectEnemy playerDetectEnemyScript;

    GameObject ClickSelect () {
        //Get mouse position and find any objects in position
        Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero, Mathf.Infinity);

        //If found object
        if (hit) {
            if (hit.collider.tag == "Monsters") {
                Debug.Log ("Hit the enemy");
                //Return enemy object found
                return GameObject.Find (hit.collider.name);
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Mouse1)) {
            targetEnemy = ClickSelect ();
        }
    }
}