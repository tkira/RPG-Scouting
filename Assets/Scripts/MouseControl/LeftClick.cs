using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClick : MonoBehaviour {
    // Start is called before the first frame update

    //Interact variables
    public GameObject targetInteract = null;
    public bool targetedInteract = false;

    //Enemy Variables
    public GameObject targetedEnemy = null;
    public bool targetEnemyInfo = false;

    //GUI Variables
    public GameObject enemyInfoGUI;

    void ClickSelect () {
        //Reads where the mouse position and finds any objects in that location
        Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero, Mathf.Infinity);

        //If an object is found
        if (hit) {
            //If object in an interactable
            if (hit.collider.tag == "Interact") {
                Debug.Log ("Hit Interact");
                //Set bool to true to show found object
                targetedInteract = true;
                //Set object so enable player to use specific object.
                targetInteract = GameObject.Find (hit.collider.name);
            } else if (hit.collider.tag == "Enemy") {
                Debug.Log ("Hit Enemy");
                //Set bool to true to show found object
                targetEnemyInfo = true;
                //Set GUI enemyinfo to active
                enemyInfoGUI.SetActive (true);
                //Set object so enable player to use specific enemy.
                targetedEnemy = GameObject.Find (hit.collider.name);
            }
        } else {
            //If no objects were found disable and clear all set objects.
            enemyInfoGUI.SetActive (false);
            targetEnemyInfo = false;
            targetedInteract = false;
            targetInteract = null;
            targetedEnemy = null;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            ClickSelect ();
        }
    }
}