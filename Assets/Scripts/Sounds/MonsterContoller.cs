using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterContoller : MonoBehaviour {
    public float vol;
    public AudioClip shoot;
    public AudioSource source;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void playshoot () {
        source.PlayOneShot (shoot, vol);
    }
}