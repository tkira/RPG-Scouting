using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {

    public PlayerDetectMonster playerDetect;
    public Animator charAni;
    public bool attacking;
    public RightClick rcChar;
    public CharacterStats charStats;

    bool attackWait;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (!rcChar.moving && playerDetect.closestEnemy != null) {
            //Start attacking animation
            if (!rcChar.attacking && !attackWait) {
                StartCoroutine (AttackLoop ());
                rcChar.attacking = true;
            }
        } else if (!rcChar.moving && playerDetect.closestEnemy == null) {
            //Stop attacking if no enemy 
            charAni.SetInteger ("MovingType", 0);
            rcChar.attacking = false;
        } else if (rcChar.moving && playerDetect.closestEnemy != null) {
            //Stop attacking if enemy and moving 
            charAni.SetInteger ("MovingType", 1);
            rcChar.attacking = false;
        }
    }

    IEnumerator AttackLoop () {
        charAni.SetInteger ("MovingType", 2);
        yield return new WaitForSeconds (1);
        charAni.SetInteger ("MovingType", 0);
        rcChar.attacking = false;
        StartCoroutine (AttackW ());
    }

    IEnumerator AttackW () {
        attackWait = true;
        yield return new WaitForSeconds (charStats.attackSpeed);
        attackWait = false;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject == playerDetect.closestEnemy){
            rcChar.stop();
        }
    }
}