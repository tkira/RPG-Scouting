using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Vector2 targetPosition;
    public int moveSpeed;
    // Start is called before the first frame update
    bool inRangeOfEnemy = false;
    //Interact Icon
    public GameObject interactIcon;

    //Reference TargetInteraction to see if player left clicked interation
    public TargetInteraction targetInter;


    // Update is called once per frame
    void Update () {
        //CLick left mouse
        if (Input.GetKeyDown (KeyCode.Mouse1)) {
            //Get position
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        } else if (targetInter.targetedInteract) {
            targetInter.targetedInteract = false;
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        }

        //Move player towards position
        transform.position = Vector2.MoveTowards (transform.position, targetPosition, Time.deltaTime * moveSpeed);

        Debug.DrawLine (this.transform.position, targetPosition);
    }

    //Stop if enemy is at max attack range of player. 
    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log ("Hit Object");
        if (col.gameObject.tag == "Enemy") {
            targetPosition = this.transform.position;
        }
    }
}