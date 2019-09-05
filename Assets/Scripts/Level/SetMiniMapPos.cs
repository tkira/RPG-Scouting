using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMiniMapPos : MonoBehaviour {
    // Start is called before the first frame update


    void Start () {
        StartCoroutine (setPos ());
    }

    IEnumerator setPos () {
        yield return new WaitForSeconds (2);
        transform.position = new Vector3 (-0.45f, -0, 0);
        transform.localScale = new Vector3 (0.2798251f, 0.4485945f, 0.2798251f);
    }

    // Update is called once per frame
    void Update () {

    }
}