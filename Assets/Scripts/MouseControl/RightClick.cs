using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour {

    //DoorCollider Script
    public DoorCollider dCol;
    public Rigidbody2D playe2d;
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
        walktime = true;
        setScale = transform.localScale;
    }

    public void teleportToNewPositionT () {
        transform.position = new Vector3 (transform.position.x, transform.position.y + 6, transform.position.z);
        StartCoroutine (Wait (transform.position));
        playe2d.velocity = Vector3.zero;
        stop ();
    }
    public void teleportToNewPositionB () {
        transform.position = new Vector3 (transform.position.x, transform.position.y - 6, transform.position.z);
        StartCoroutine (Wait (transform.position));
        playe2d.velocity = Vector3.zero;
        stop ();
    }
    public void teleportToNewPositionR () {
        transform.position = new Vector3 (transform.position.x + 4, transform.position.y, transform.position.z);
        StartCoroutine (Wait (transform.position));
        playe2d.velocity = Vector3.zero;
        stop ();
    }
    public void teleportToNewPositionL () {
        transform.position = new Vector3 (transform.position.x - 4, transform.position.y, transform.position.z);
        playe2d.velocity = Vector3.zero;
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

    int keyPress;

    // Update is called once per frame
    void Update () {

        //Move with WASD or Arrows
        if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5) {
            keyPress = 1;
            transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * characterStats.moveSpeed * Time.deltaTime, 0f, 0f));
            //Moving Right
            animator.SetInteger ("MovingType", 1);
            moving = true;
            if (Input.GetKeyDown (KeyCode.A) || (Input.GetKeyDown (KeyCode.LeftArrow))) {
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
            } else if (Input.GetKeyDown (KeyCode.D) || (Input.GetKeyDown (KeyCode.RightArrow))) {
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
            }
            targetPosition = transform.position;
            transform.position = targetPosition;
        }

        if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5) {
            keyPress = 1;
            transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * characterStats.moveSpeed * Time.deltaTime, 0f));
            targetPosition = transform.position;
            transform.position = targetPosition;
            animator.SetInteger ("MovingType", 1);
        }

        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.UpArrow)) {
            keyPress = 1;
        } else {
            keyPress = 0;
        }

        //Select idle animation
        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y && !attacking && keyPress == 0) {
            animator.SetInteger ("MovingType", 0);
            moving = false;
        }

        //CLick left mouse, also disable if moving rooms
        if (Input.GetKeyDown (KeyCode.Mouse1) && !dCol.keyEntered) {
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

        if (moving && walktime) {
            asssc.pwalk ();
            StartCoroutine (walkwait ());
        }
        Debug.DrawLine (this.transform.position, targetPosition);
    }

    public float walkinter;
    public PlayerWalk asssc;
    bool walktime;
    IEnumerator walkwait () {
        walktime = false;
        yield return new WaitForSeconds (walkinter);
        walktime = true;
    }

    public void flipPlayerLeft () {
        transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
    }

    public void flipPlayerRight () {
        transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
    }

}