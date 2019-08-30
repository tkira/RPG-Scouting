using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 = Top
    // 2 = Bottom
    // 4 = Left
    // 8 = Right

    // May be causing an error if a wall spawns next to it when it is spawning (random spawning time may help with this?)

    private RoomTemplates templates;

    private MonsterTemplates monstersTemplates;
    private int rand;
    private bool spawned = false;
    private bool notRight = false;
    private bool notLeft = false;
    private bool notBottom = false;
    private bool notTop = false;
    private bool Right = false;
    private bool Left = false;
    private bool Bottom = false;
    private bool Top = false;
    private int closedValues = 0;

    public GameObject mapDoor;

    void Start(){

        float y = 0;
        float x = 0;
        //float rand1 = Random.Range(0.1f,0.9f); //May prevent the spawning doors next to walls
        switch(openingDirection)
        {
            case 1:
                Top = true;
                y = (0.0313f * (transform.position.y + 4.5f)) + 3;
                x = (0.0313f * (transform.position.x + 0)) + 5.5f;
                break;
            case 2:
                Bottom = true; 
                y = (0.0313f * (transform.position.y - 4.5f)) + 3;
                x = (0.0313f * (transform.position.x + 0)) + 5.5f;
                break;
            case 4:
                Left = true;
                y = (0.0313f * (transform.position.y + 0)) + 3;
                x = (0.0313f * (transform.position.x - 8)) + 5.5f;
                break;
            case 8:
                Right = true; 
                y = (0.0313f * (transform.position.y + 0)) + 3;
                x = (0.0313f * (transform.position.x + 8)) + 5.5f;
                break;
               
        }

        Instantiate(mapDoor,new Vector3(x,y,0), Quaternion.identity);

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        monstersTemplates = GameObject.FindGameObjectWithTag("Monsters").GetComponent<MonsterTemplates>();
        Invoke("Spawn", 0.1f);
    }      

    // Update is called once per frame
    void Spawn()
    {
        
        while(spawned == false){
            
            GameObject[] possibleRooms = templates.allRooms;
            openingDirection = (1 * ((Top) ? 1: 0)) + (2 * ((Bottom) ? 1: 0)) + (4 * ((Left) ? 1: 0)) + (8 * ((Right) ? 1: 0));

            int changeChecker = openingDirection + closedValues; //Used to make sure the chosen piece still fits.
            int totalValue = openingDirection + closedValues;

            //Debug.Log("Value: " + totalValue);
            if(totalValue >= 128){ //Not right
                possibleRooms = possibleRooms.Intersect(templates.notRightRooms).ToArray();
                totalValue = totalValue - 128;
                //Debug.Log("Not Right: " + possibleRooms.Length);
                notRight = true;
            }
            if(totalValue >= 64){ //Not Left
                possibleRooms = possibleRooms.Intersect(templates.notLeftRooms).ToArray();
                totalValue = totalValue - 64;
                //Debug.Log("Not Left: " + possibleRooms.Length);
                notLeft = true;
            }
            if(totalValue >= 32){ //Not Bottom
                possibleRooms = possibleRooms.Intersect(templates.notBottomRooms).ToArray();
                totalValue = totalValue - 32;
                //Debug.Log("Not Bottom: " + possibleRooms.Length);
                notBottom = true;
            }
            if(totalValue >= 16){ //Not Top
                possibleRooms = possibleRooms.Intersect(templates.notTopRooms).ToArray();
                totalValue = totalValue - 16;
                //Debug.Log("Not Top: " + possibleRooms.Length);
                notTop = true;
            }
            if(totalValue >= 8){ //Right
                if(!notRight){
                    possibleRooms = possibleRooms.Intersect(templates.rightRooms).ToArray();
                }
                totalValue = totalValue - 8;
                //Debug.Log("Right: " + possibleRooms.Length);
            }
            if(totalValue >= 4){ //Left
                if(!notLeft){
                    possibleRooms = possibleRooms.Intersect(templates.leftRooms).ToArray();
                }
                totalValue = totalValue - 4;
                //Debug.Log("Left: " + possibleRooms.Length);
            }
            if(totalValue >= 2){ //Bottom
                if(!notBottom){
                    possibleRooms = possibleRooms.Intersect(templates.bottomRooms).ToArray();
                }
                totalValue = totalValue - 2;
                //Debug.Log("Bottom: " + possibleRooms.Length);
            }
            if(totalValue == 1){ //Top
                if(!notTop){
                    possibleRooms = possibleRooms.Intersect(templates.topRooms).ToArray();
                }
                totalValue = totalValue - 1;
                //Debug.Log("Top: " + possibleRooms.Length);
            }

            //Debug.Log("ArrayLength: " + possibleRooms.Length);

            if(changeChecker == openingDirection + closedValues){ //If it doesnt still match it will reloop
                rand=Random.Range(0,possibleRooms.Length);
                GameObject newObject = (GameObject)Instantiate(possibleRooms[rand], transform.position, Quaternion.identity);
                //
                //Debug.Log(newObject.GetInstanceID());
                newObject.GetComponentInChildren<AlreadyRoomHere>().spawnVal = changeChecker;
                spawned = true;

                int rand2=Random.Range(0,30);
                if(rand2 % 2 == 0){
                    Debug.Log("Spawn Monster");
                    Instantiate(monstersTemplates.monster, new Vector3(newObject.transform.position.x + 3.5f, newObject.transform.position.y + 1.5f, 0) , Quaternion.identity);
                }
                if(rand2 % 3 == 0){
                    Debug.Log("Spawn Monster");
                    Instantiate(monstersTemplates.monster, new Vector3(newObject.transform.position.x - 3.5f, newObject.transform.position.y - 1.5f, 0) , Quaternion.identity);
                }
                if(rand2 % 5 == 0){
                    Debug.Log("Spawn Monster");
                    Instantiate(monstersTemplates.monster, new Vector3(newObject.transform.position.x + 3.5f, newObject.transform.position.y - 1.5f, 0) , Quaternion.identity);
                }
                if(rand2 % 10 == 0){
                    Debug.Log("Spawn Monster");
                    Instantiate(monstersTemplates.monster, new Vector3(newObject.transform.position.x - 3.5f, newObject.transform.position.y + 1.5f, 0) , Quaternion.identity);
                }

                int rand3=Random.Range(0,10);
                if(rand3 == 0){
                    Debug.Log("Spawn Monster");
                    Instantiate(monstersTemplates.chest, newObject.transform.position, Quaternion.identity);
                    float y = (0.0313f * transform.position.y) + 3;
                    float x = (0.0313f * transform.position.x) + 5.5f;
                    Instantiate(monstersTemplates.mapChest,new Vector3(x,y,0), Quaternion.identity);
                }
            }
            else{
                Debug.Log("Didnt Match");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if (GetInstanceID() < other.gameObject.GetInstanceID()) //Compares the id so that only one is destroyed
            {
                //openingDirection = openingDirection + other.GetComponent<RoomSpawner>().openingDirection; //Seems it may be adding this twice?
                if(other.GetComponent<RoomSpawner>().Top){ //Should prevent it added values twice
                    Top = true;
                }
                if(other.GetComponent<RoomSpawner>().Bottom){ //Should prevent it added values twice
                    Bottom = true;
                }
                if(other.GetComponent<RoomSpawner>().Left){ //Should prevent it added values twice
                    Left = true;
                }
                if(other.GetComponent<RoomSpawner>().Right){ //Should prevent it added values twice
                    Right = true;
                }
                Destroy(other.gameObject);
            }
        }
        if(other.CompareTag("NotSpawnPoint")){
            closedValues = closedValues + other.GetComponent<RoomNotSpawner>().closedDirection;
            //Destroy(other.gameObject);
        }
        if(other.CompareTag("AlreadyRoom")){

            Destroy(gameObject);
        }
    }
}
