using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public float vol;
    public AudioClip swordHit;
    public AudioClip swordMiss;
    public AudioClip uiopen;
    public AudioSource source;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void playSwordHit () {
        source.PlayOneShot (swordHit, vol);
    }

    public void playSwordMiss () {
        source.PlayOneShot (swordMiss, vol);
    }

    public void playUiopen () {
        source.PlayOneShot (uiopen, vol);
    }
}