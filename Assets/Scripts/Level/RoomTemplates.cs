﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] allRooms;
    public GameObject[] notBottomRooms;
    public GameObject[] notTopRooms;
    public GameObject[] notLeftRooms;
    public GameObject[] notRightRooms;

    public List<GameObject> PuzzleRooms;

    public List<GameObject> rooms;

    public float waitTime;
    public bool spawnedStairs = false;
    public GameObject stairs;

    public GameObject mapStairs;

    // Update is called once per frame
    void Update () {
        if (waitTime <= 0 && !spawnedStairs) {
            //var nonintersect = rooms.Except(PuzzleRooms).Union( rooms.Except(PuzzleRooms));
            int x = 1;
            while(x <rooms.Count-1){
                if(PuzzleRooms.Contains(rooms[rooms.Count - x])){
                    x++;
                }
                else{
                    Instantiate (stairs, rooms[rooms.Count - x].transform.position, Quaternion.identity);
                    break;
                }
            }

            GameObject mapS = Instantiate (mapStairs, new Vector3 ((0.0313f * rooms[rooms.Count - x].transform.position.x) + 5.5f, (0.0313f * rooms[rooms.Count - x].transform.position.y) + 3, 0), Quaternion.identity);
            mapS.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);

        spawnedStairs = true;
    } else {
        waitTime -= Time.deltaTime;
    }
}
}