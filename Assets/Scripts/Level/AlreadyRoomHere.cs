using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlreadyRoomHere : MonoBehaviour {
    public int spawnVal;
    public GameObject mapRoom;
    public bool spawnMap = true;

    void Start () {
        if (spawnMap) {
            float y = (0.0313f * transform.position.y) + 3;
            float x = (0.0313f * transform.position.x) + 5.5f;
            GameObject mapR = Instantiate (mapRoom, new Vector3 (x, y, 0), Quaternion.identity);
            mapR.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);
        }
    }
    void OnTriggerEnter2D (Collider2D other) {

        //Destroy (other);

    }
}