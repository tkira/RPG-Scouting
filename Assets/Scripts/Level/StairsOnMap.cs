using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsOnMap : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject mapStairs;
    public GameObject mapPlayer;

    void Start () {

        GameObject mapS = Instantiate (mapStairs,  new Vector3 ((0.0313f * transform.position.x) + 5.5f, (0.0313f * transform.position.y) + 3, 0), Quaternion.identity);
        GameObject mapP = Instantiate (mapPlayer,  new Vector3 ((0.0313f * transform.position.x) + 5.5f, (0.0313f * transform.position.y) + 3, 0), Quaternion.identity);
        mapS.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);
        mapP.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);
    }

    // Update is called once per frame
    void Update () {

    }
}