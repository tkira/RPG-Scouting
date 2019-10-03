using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour {
    Transform thisTransform;

    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2 (1, 4);
    float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero, Vector3.zero };
    int currentMoveDirection;

    public Animator ani;
    Vector3 setScale;

    // Use this for initialization
    void Start () {
        // Cache the transform for quicker access
        thisTransform = this.transform;

        // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        decisionTimeCount = Random.Range (decisionTime.x, decisionTime.y);

        ani = GetComponent<Animator> ();
        setScale = transform.localScale;
        // Choose a movement direction, or stay in place
        ChooseMoveDirection ();
    }

    // Update is called once per frame
    void Update () {
        // Move the object in the chosen direction at the set speed
        thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

        if (currentMoveDirection == 0) {
            transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);
            ani.SetInteger ("MovingType", 1);
        } else if (currentMoveDirection == 1) {
            transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
            ani.SetInteger ("MovingType", 1);
        } else if (currentMoveDirection == 2) {
            ani.SetInteger ("MovingType", 1);
        } else if (currentMoveDirection == 3) {
            ani.SetInteger ("MovingType", 1);
        } else if (currentMoveDirection == 4) {
            ani.SetInteger ("MovingType", 1);
        } else {
            ani.SetInteger ("MovingType", 0);
        }

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else {
            // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            decisionTimeCount = Random.Range (decisionTime.x, decisionTime.y);

            // Choose a movement direction, or stay in place
            ChooseMoveDirection ();
        }
    }

    void ChooseMoveDirection () {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt (Random.Range (0, moveDirections.Length));
    }
}