using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {

    public PlayerDetectEnemy playerDetect;
    public Animator charAni;
    public bool attacking;
    public RightClick rcPlayer;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (playerDetect.closestEnemy != null) {
            //Start attacking animation
            charAni.SetInteger ("MovingType", 2);
            attacking = true;
        } else if (!rcPlayer.moving && playerDetect.closestEnemy == null) {
            //Stop attacking if no enemy 
            charAni.SetInteger ("MovingType", 0);
            attacking = false;
        } else if (rcPlayer.moving && playerDetect.closestEnemy != null) {
            //Stop attacking if enemy and moving 
            charAni.SetInteger ("MovingType", 1);
            attacking = false;
        }
    }
}