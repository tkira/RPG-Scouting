using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkill : MonoBehaviour {

    public GameObject explosionSprite;
    public bool skillRunning;
    public int cooldown;

    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {

    }

    public void runSkill () {
        if (!skillRunning) {
            explosionSprite.SetActive (true);
            skillRunning = true;
            StartCoroutine (SkillAnimation ());
        }
    }

    IEnumerator SkillAnimation () {
        yield return new WaitForSeconds (1);
        skillRunning = false;
        explosionSprite.SetActive (false);
    }
}