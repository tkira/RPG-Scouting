﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCombatDetect : MonoBehaviour {
    public MonsterAI monAI;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player") {

        }
    }
}