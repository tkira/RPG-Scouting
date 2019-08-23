using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMouseHover : MonoBehaviour {

    public GameObject mouseIcon;

    void OnMouseOver () {
        mouseIcon.SetActive (true);
    }

    void OnMouseExit () {
        mouseIcon.SetActive (false);
    }

    // Update is called once per frame
    void Update () {

    }
}