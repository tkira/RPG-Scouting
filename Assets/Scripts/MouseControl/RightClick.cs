using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour {

    //Check what direction character is facing
    public bool facingLeft;
    public Animator animator;
    Vector3 setScale;

    public Vector2 targetPosition;
    // Start is called before the first frame update
    bool inRangeOfEnemy = false;
    //Interact Icon
    public GameObject interactIcon;

    //Reference TargetInteraction to see if player left clicked interation
    public LeftClick targetInter;

    //Get movement of Current Character
    public CharacterStats characterStats;

    void Start () {
        setScale = transform.localScale;
    }

    public void teleportToNewPositionT () {
        transform.position = new Vector3 (transform.position.x, transform.position.y + 4, transform.position.z);
        StartCoroutine (Wait (transform.position));
    }
    public void teleportToNewPositionB () {
        transform.position = new Vector3 (transform.position.x, transform.position.y - 4, transform.position.z);
        StartCoroutine (Wait (transform.position));
    }
    public void teleportToNewPositionR () {
        transform.position = new Vector3 (transform.position.x + 4, transform.position.y, transform.position.z);
        StartCoroutine (Wait (transform.position));
    }
    public void teleportToNewPositionL () {
        transform.position = new Vector3 (transform.position.x - 4, transform.position.y, transform.position.z);
        StartCoroutine (Wait (transform.position));
    }

    IEnumerator Wait (Vector3 pos) {
        yield return new WaitForSeconds (0.1f);
        targetPosition = pos;
    }

    // Update is called once per frame
    void Update () {
        //Select idle animation
        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y) {
            animator.SetBool ("Moving", false);
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
                animator.SetBool ("Moving", true);
                //Moving Left
            } else if (targetPosition.x < transform.position.x) {
                //Flip Character
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                //Set Walking Animation
                animator.SetBool ("Moving", true);
            }
        } else if (targetInter.targetedInteract) {
            targetInter.targetedInteract = false;
            targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (targetPosition.x > transform.position.x) {
                transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
                animator.SetBool ("Moving", true);
            } else if (targetPosition.x < transform.position.x) {
                transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
                animator.SetBool ("Moving", true);
            }
        }

        //Move player towards position
        transform.position = Vector2.MoveTowards (transform.position, targetPosition, Time.deltaTime * characterStats.moveSpeed);

        Debug.DrawLine (this.transform.position, targetPosition);
    }
}