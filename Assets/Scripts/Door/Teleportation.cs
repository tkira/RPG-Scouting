using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleportation : MonoBehaviour
{
    public GameObject Player;
    public GameObject Current;
    float xPos;
    float yPos;
    float zPos;
    bool trigger = false;

    void Start()
    {       
        GameObject.Find("Main Camera").transform.position = new Vector3((float)0.1, (float)-0.9, (float)-10);
    }

    //----------------------
    void Update()
    {
        xPos = GameObject.Find("Player").transform.position.x;
        yPos = GameObject.Find("Player").transform.position.y;
        zPos = GameObject.Find("Player").transform.position.z;   
    }

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("player de");
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            if (Current.gameObject.tag == "Top Door")
    //            {
    //                Debug.Log("door de");
    //                movecameraup();
    //            }
                    
    //        }
    //    }
    //}


    //----------------------


    public void movecameraup()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3((float)0.1, (float)16.5, (float)-10);

        GameObject.Find("Player").transform.position = new Vector3(xPos, yPos+=4, zPos);
    }

}
