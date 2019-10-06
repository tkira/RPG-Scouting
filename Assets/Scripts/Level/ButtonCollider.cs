﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
    public bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Box")) {
            pressed = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Box")) {
            pressed = false;
        }
    }
}
