using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeCollider : MonoBehaviour {

    public RightClick rcCharacter;

    //Enable object if in range
    void OnTriggerStay2D (Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            rcCharacter.inRangeOfEnemy = true;
            rcCharacter.animator.SetInteger ("MovingType", 2);
        }
    }

    //Disable if exit 
    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
           rcCharacter.inRangeOfEnemy = false;
           rcCharacter.animator.SetInteger ("MovingType", 0);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}