using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoutingSystem : MonoBehaviour {

    public GlobalVariablesController gvc;
    public int scoutingLvl;
    // Start is called before the first frame update
    void Start () {
        gvc = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariablesController> ();
        scoutingLvl = gvc.scoutingLvl;
    }

    // Update is called once per frame
    void Update () {

    }
}