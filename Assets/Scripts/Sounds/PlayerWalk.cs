using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
    public float vol;
    public AudioClip walk;
    public AudioClip walk2;
    public AudioSource source;
    bool walkRotation;
    // Start is called before the first frame update
    void Start () {
        walkRotation = true;
    }

    // Update is called once per frame
    void Update () {

    }

    public void pwalk () {
        if (walkRotation) {
            source.PlayOneShot (walk, vol);
            walkRotation = false;
        } else {
            source.PlayOneShot (walk2, vol);
            walkRotation = true;
        }
    }
}