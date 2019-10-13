using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : MonoBehaviour {

    public GameObject playerSprite;
    public bool skillRunning;
    public int cooldown;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {

    }

    public void runSkill () {
        if (!skillRunning) {
            GameObject player;
            player = Instantiate (playerSprite, playerPos.transform.position, Quaternion.identity);
            player.transform.position = playerPos.transform.position;
            skillRunning = true;
            StartCoroutine (SkillAnimation ());
        }
    }

    IEnumerator SkillAnimation () {
        yield return new WaitForSeconds (1);
        skillRunning = false;

    }
}