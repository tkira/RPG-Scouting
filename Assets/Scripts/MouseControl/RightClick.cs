using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour {

    //DoorCollider Script
    public DoorCollider dCol;

    //Check what direction character is facing
    public bool facingLeft;
    public Animator animator;
    Vector3 setScale;

    public Vector2 targetPosition;

    //Interact Icon
    public GameObject interactIcon;

    //Reference TargetInteraction to see if player left clicked interation
    public LeftClick targetInter;

    //Get movement of Current Character
    public CharacterStats characterStats;

    public bool moving;
    public bool attacking;

    void Start () {
        setScale = transform.localScale;
    }

    public void teleportToNewPositionT () {
        transform.position = new Vector3 (transform.position.x, transform.position.y + 6, transform.position.z);
        StartCoroutine (Wait (transform.position));
        stop ();
    }
    public void teleportToNewPositionB () {
        transform.position = new Vector3 (transform.position.x, transform.position.y - 6, transform.position.z);
        StartCoroutine (Wait (transform.position));
        stop ();
    }
    public void teleportToNewPositionR () {
        transform.position = new Vector3 (transform.position.x + 4, transform.position.y, transform.position.z);
        StartCoroutine (Wait (transform.position));
        stop ();
    }
    public void teleportToNewPositionL () {
        transform.position = new Vector3 (transform.position.x - 4, transform.position.y, transform.position.z);
        StartCoroutine (Wait (transform.position));
        stop ();
    }

    public void stop () {
        targetPosition = transform.position;
        transform.position = targetPosition;
        animator.SetInteger ("MovingType", 0);
        moving = false;
    }

    IEnumerator Wait (Vector3 pos) {
        yield return new WaitForSeconds (0.1f);
        targetPosition = pos;
    }

    // Update is called once per frame
    void Update () {
        //Select idle animation
        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y && !attacking) {
            animator.SetInteger ("MovingType", 0);
            moving = false;
        }

        //CLick left mouse, also disable if moving rooms
        if (Input.GetKeyDown (KeyCode.Mouse1) && !dCol.keyEntered && !attacking) {
            //Get position
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

            //Moving Right
            if (targetPosition.x > transform.position.x) {
                //Flip Character
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
                //Set Walking Animation
                animator.SetInteger ("MovingType", 1);
                moving = true;
                //Moving Left
            } else if (targetPosition.x < transform.position.x) {
                //Flip Character
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                //Set Walking Animation
                animator.SetInteger ("MovingType", 1);
                moving = true;
            }
        } else if (targetInter.targetedInteract) {
            targetInter.targetedInteract = false;
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (targetPosition.x > transform.position.x) {
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
                animator.SetInteger ("MovingType", 1);
                moving = true;
            } else if (targetPosition.x < transform.position.x) {
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                animator.SetInteger ("MovingType", 1);
                moving = true;
            }
        }
        //Move player towards position
        transform.position = Vector2.MoveTowards (transform.position, targetPosition, Time.deltaTime * characterStats.moveSpeed);

        Debug.DrawLine (this.transform.position, targetPosition);
    }

    public void flipPlayerLeft () {
        transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
    }

    public void flipPlayerRight () {
        transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
    }
}