﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractCollider : MonoBehaviour {

    public GameObject interactIcon;
    public GameObject Portal;
    public GameObject Player;
    public GameObject DoorIcon;
    bool Ttrigger = false;
    bool Btrigger = false;
    bool Rtrigger = false;
    bool Ltrigger = false;
    float xPos;
    float yPos;
    float xPosCamera;
    float yPosCamera;
    float zPos;
    //Enable object if in range


    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log ("Hit Object");
        //-----interactable icons
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive(true);
        }
        //-----Door icon & triggers
        if (col.gameObject.tag == "Top Door")
        {
            DoorIcon.SetActive(true);
            Ttrigger = true;
        }
        if (col.gameObject.tag == "Right Door")
        {
            Rtrigger = true;
            DoorIcon.SetActive(true);
        }
        if(col.gameObject.tag == "Bottom Door")
        {
            Btrigger = true;
            DoorIcon.SetActive(true);
        }
        if(col.gameObject.tag == "Left Door")
        {
            Ltrigger = true;
            DoorIcon.SetActive(true);
        }
     }

   
//Disable if exit 
    void OnTriggerExit2D (Collider2D col) {
        Debug.Log ("Exit Object");
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive(false);
        }
        //-----Door icon & triggers
        if (col.gameObject.tag == "Top Door")
        {
            DoorIcon.SetActive(false);
            Ttrigger = false;
        }
        if (col.gameObject.tag == "Right Door")
        {
            Rtrigger = false;
            DoorIcon.SetActive(false);
        }
        if(col.gameObject.tag == "Bottom Door")
        {
            Btrigger = false;
            DoorIcon.SetActive(false);
        }
        if (col.gameObject.tag == "Left Door")
        {
            Ltrigger = false;
            DoorIcon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        xPos = GameObject.Find("Player").transform.position.x;
        yPos = GameObject.Find("Player").transform.position.y;
        zPos = GameObject.Find("Player").transform.position.z;
        xPosCamera = GameObject.Find("Main Camera").transform.position.x;
        yPosCamera = GameObject.Find("Main Camera").transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Ttrigger == true)
            {
                movecameraup();
                Debug.Log("Toptriggerworked");
            }
            if (Rtrigger == true)
            {
                movecameraright();
                Debug.Log("Righttriggerworked");
            }
            if (Ltrigger == true)
            {
                movecameraleft();
                Debug.Log("Lefttriggerworked");
            }
            if (Btrigger == true)
            {
                movecameradown();
                Debug.Log("Bottomtriggerworked");
            }
        }

    }

    public void movecameraup()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(xPosCamera, yPosCamera += 16.5f, (float)-10);

        GameObject.Find("Player").transform.position = new Vector3(xPos, yPos += 7, zPos);
    }
    public void movecameraright()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(xPosCamera += 30, yPosCamera, (float)-10);

        GameObject.Find("Player").transform.position = new Vector3(xPos += 5, yPos, zPos);
    }
    public void movecameraleft()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(xPosCamera -= 30f, yPosCamera, (float)-10);

        GameObject.Find("Player").transform.position = new Vector3(xPos -= 5, yPos, zPos);
    }
    public void movecameradown()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(xPosCamera, yPosCamera -= 16.5f, (float)-10);

        GameObject.Find("Player").transform.position = new Vector3(xPos, yPos -= 7, zPos);
    }




}
