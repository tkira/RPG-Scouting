using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorCollider : MonoBehaviour {

    public GameObject interactIcon;
    public GameObject DoorIcon;
    public GameObject camera;
    bool Ttrigger = false;
    bool Btrigger = false;
    bool Rtrigger = false;
    bool Ltrigger = false;
    bool keyEntered = false;
    bool singleCheck = false;
    //Enable object if in range

    public RightClick rcPlayer;

    void OnTriggerEnter2D (Collider2D col) {
        //-----interactable icons
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive (true);
        }

        //-----Door icon & triggers
        if (col.gameObject.tag == "TopDoor") {
            DoorIcon.SetActive (true);
            Ttrigger = true;
            singleCheck = true;
        }
        if (col.gameObject.tag == "RightDoor") {
            Rtrigger = true;
            DoorIcon.SetActive (true);
            singleCheck = true;
        }
        if (col.gameObject.tag == "BottomDoor") {
            Btrigger = true;
            DoorIcon.SetActive (true);
            singleCheck = true;
        }
        if (col.gameObject.tag == "LeftDoor") {
            Ltrigger = true;
            DoorIcon.SetActive (true);
            singleCheck = true;
        }
    }

    //Disable if exit 
    void OnTriggerExit2D (Collider2D col) {
        Debug.Log ("Exit Object");
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive (false);
        }
        //-----Door icon & triggers
        if (col.gameObject.tag == "TopDoor") {
            DoorIcon.SetActive (false);
            Ttrigger = false;
            singleCheck = false;
        }
        if (col.gameObject.tag == "Right Door") {
            Rtrigger = false;
            DoorIcon.SetActive (false);
            singleCheck = false;
        }
        if (col.gameObject.tag == "Bottom Door") {
            Btrigger = false;
            DoorIcon.SetActive (false);
            singleCheck = false;
        }
        if (col.gameObject.tag == "Left Door") {
            Ltrigger = false;
            DoorIcon.SetActive (false);
            singleCheck = false;
        }
    }

    Vector3 startPos;
    public float speed;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            keyEntered = true;
            startPos = camera.transform.position;
        }
        if (Ttrigger == true && keyEntered == true) {
            FadeIn ();
            StartCoroutine (Wait ());
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x, startPos.y + 9f, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x, startPos.y + 9f, startPos.z)) {
                keyEntered = false;
            }
        }
        if (Rtrigger == true && keyEntered == true) {
            FadeIn ();
            StartCoroutine (Wait ());
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x + 16f, startPos.y, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x + 16f, startPos.y, startPos.z)) {
                keyEntered = false;
            }
        }
        if (Ltrigger == true && keyEntered == true) {
            FadeIn ();
            StartCoroutine (Wait ());
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x - 16f, startPos.y, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x - 16f, startPos.y, startPos.z)) {
                keyEntered = false;
            }
        }
        if (Btrigger == true && keyEntered == true) {
            FadeIn ();
            StartCoroutine (Wait ());
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x, startPos.y - 9f, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x, startPos.y - 9f, startPos.z)) {
                keyEntered = false;
            }
        }
    }

    public CanvasGroup uiElement;

    void FadeIn () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 1, .2f));
    }

    void FadeOut () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup (CanvasGroup cg, float start, float end, float lerpTime) {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true) {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp (start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate ();
        }
        FadeOut ();
        print ("done");
    }

    IEnumerator Wait () {
        yield return new WaitForSeconds (2f);
        if (Ttrigger == true && singleCheck == true) {
            rcPlayer.teleportToNewPositionT ();
            singleCheck = false;
        }
        if (Rtrigger == true && singleCheck == true) {
            rcPlayer.teleportToNewPositionR ();
            singleCheck = false;
        }
        if (Ltrigger == true && singleCheck == true) {
            rcPlayer.teleportToNewPositionL ();
            singleCheck = false;
        }
        if (Btrigger == true && singleCheck == true) {
            rcPlayer.teleportToNewPositionB ();
            singleCheck = false;
        }
    }

}