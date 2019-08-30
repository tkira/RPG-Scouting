using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour {

    public Collider2D combatCollider;

    //Check what direction character is facing
    public bool facingLeft;
    public Animator animator;
    Vector3 setScale;

    public Vector2 targetPosition;
    // In range of enemy 
    public bool inRangeOfEnemy = false;
    //Interact Icon
    public GameObject interactIcon;

    //Reference TargetInteraction to see if player left clicked interation
    public LeftClick targetInter;

    //Get movement of Current Character
    public CharacterStats characterStats;

    void Start () {
        setScale = transform.localScale;
    }

    // Update is called once per frame
    void Update () {
        //Select idle animation
        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y && inRangeOfEnemy == false) {
            animator.SetInteger ("MovingType", 0);
        }

        //CLick left mouse
        if (Input.GetKeyDown (KeyCode.Mouse1)) {
            //Get position
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

            //Moving Right
            if (targetPosition.x > transform.position.x) {
                //Flip Character
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
                //Set Walking Animation
                animator.SetInteger ("MovingType", 1);
                //Moving Left
            } else if (targetPosition.x < transform.position.x) {
                //Flip Character
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                //Set Walking Animation
                animator.SetInteger ("MovingType", 1);
            }
        } else if (targetInter.targetedInteract) {
            targetInter.targetedInteract = false;
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (targetPosition.x > transform.position.x) {
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
                animator.SetInteger ("MovingType", 1);
            } else if (targetPosition.x < transform.position.x) {
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                animator.SetInteger ("MovingType", 1);
            }
        }

        //Move player towards position
        transform.position = Vector2.MoveTowards (transform.position, targetPosition, Time.deltaTime * characterStats.moveSpeed);

        Debug.DrawLine (this.transform.position, targetPosition);
    }
}