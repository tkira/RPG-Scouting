using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour {

    public GameObject targetEnemy = null;
    public bool targetedEnemy = false;
    public PlayerDetectEnemy playerDetectEnemyScript;

    GameObject ClickSelect () {
        Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero, Mathf.Infinity);

        if (hit) {
            if (hit.collider.tag == "Enemy") {
                Debug.Log ("Hit the enemy");
                //Disable auto target
                playerDetectEnemyScript.runPlayerDetectEnemyScript = false;
                return GameObject.Find (hit.collider.name);
            }
        }

        //Enable auto target PlayerDetectEnemy
        playerDetectEnemyScript.runPlayerDetectEnemyScript = true;
        return null;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Mouse1)) {
            targetEnemy = ClickSelect ();
        }
    }
}