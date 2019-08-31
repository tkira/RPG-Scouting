using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsOnMap : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject mapStairs;

    void Start () {

        float y = (0.0313f * transform.position.y) + 3;
        float x = (0.0313f * transform.position.x) + 5.5f;
        GameObject mapS = Instantiate (mapStairs, new Vector3 (x, y, 0), Quaternion.identity);
        mapS.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);
    }

    // Update is called once per frame
    void Update () {

    }
}