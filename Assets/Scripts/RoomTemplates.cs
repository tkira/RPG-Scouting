using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] allRooms;
    public GameObject[] notBottomRooms;
    public GameObject[] notTopRooms;
    public GameObject[] notLeftRooms;
    public GameObject[] notRightRooms;

    public List<GameObject> rooms;

    public float waitTime;
    public bool spawnedStairs = false;
    public GameObject stairs;

    public GameObject mapStairs;

        // Update is called once per frame
    void Update()
    {
        if(waitTime <=0 && !spawnedStairs){
            Instantiate(stairs, rooms[rooms.Count-1].transform.position, Quaternion.identity);

            float y = (0.0313f * rooms[rooms.Count-1].transform.position.y) + 3;
            float x = (0.0313f * rooms[rooms.Count-1].transform.position.x) + 5.5f;
            Instantiate(mapStairs,new Vector3(x,y,0), Quaternion.identity);
            spawnedStairs = true;
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}
