using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTemplates : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject chest;

    public GameObject mapChest;

    public bool doorClosed;

    void Start(){
        doorClosed = true;
    }
    
    void Update() //Only allows the doors to open once all of the monsters are dead.
    {
        if(GameObject.FindGameObjectsWithTag("MonsterHitbox").Length <= 0){
            doorClosed = false;
        }
        else{
            doorClosed = true;
        }
             
    }
}
