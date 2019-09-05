using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsOnMap : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject mapStairs;

    void Start () {

        GameObject mapS = Instantiate (mapStairs, transform.position, Quaternion.identity);
        mapS.transform.SetParent (GameObject.FindGameObjectWithTag ("MapGUI").transform, false);

        transform.position = new Vector3 ((0.0313f * transform.position.x) + 5.5f, (0.0313f * transform.position.y) + 3, 0);
    }

    // Update is called once per frame
    void Update () {

    }
}