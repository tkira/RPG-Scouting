﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFunctions : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        StartCoroutine (alive ());

    }

    // Update is called once per frame
    void Update () {

    }

    public IEnumerator alive () {
        yield return new WaitForSeconds (5);
        Destroy (gameObject);
    }

}