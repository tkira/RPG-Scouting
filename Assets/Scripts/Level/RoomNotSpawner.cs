using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNotSpawner : MonoBehaviour
{
    public int closedDirection;
    // 16 = Not Top
    // 32 = Not Bottom
    // 64 = Not Left
    // 128 = Not Right

    // Update is called once per frame

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("AlreadyRoom")){

            Destroy(gameObject);
        }
    }
}
