using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectMonster : MonoBehaviour {

    //DetectRange 
    public float enemyDetectRange;

    //Bool in range of an enemy
    public bool inRangeEnemy = false;

    //Gameobject of closest enemy
    public GameObject closestEnemy = null;

    //Distance of closest enemy
    public float closestDis = 0;

    public RightClick rcCharacter;

    // Update is called once per frame
    void Update () {
        //run function findclostedenemy
        closestEnemy = FindClosestEnemy ();
        //if found enemy set distance.
        if (closestEnemy != null) {
            inRangeEnemy = true;
            closestDis = (closestEnemy.transform.position - transform.position).sqrMagnitude;
            Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
        } else {
            //set false of no enemies found.
            inRangeEnemy = false;
        }

    }

    public GameObject[] monsters;
    public List<GameObject> monstersInRange;
    public GameObject FindClosestEnemy () {
        //get list if all enemies.
        monsters = GameObject.FindGameObjectsWithTag ("Monsters");

        monstersInRange = new List<GameObject> ();
        //Get search all enemies in range.
        foreach (GameObject monster in monsters) {
            float curDistance = (monster.transform.position - transform.position).sqrMagnitude;
            if (curDistance <= enemyDetectRange) {
                monstersInRange.Add (monster);
            }
        }

        //No enemies in range
        if (monstersInRange.Count == 0) {
            return null;
        }

        //Find the closest enemy in enemiesInRange
        GameObject closest = null;
        //If one enemy, set only enemy
        if (monstersInRange.Count == 1) {
            closest = monstersInRange[0];
        } else if (monstersInRange.Count > 1) {
            //If the is multiple in range sort and find the closest
            for (int i = 1; i < monstersInRange.Count; i++) {
                //Set first enemy
                if (closest == null) {
                    closest = monstersInRange[0];
                }
                float cloDistance = (closest.transform.position - transform.position).sqrMagnitude;
                float curDistance = (monstersInRange[i].transform.position - transform.position).sqrMagnitude;
                //compare current enemy with another and set if closer.
                if (curDistance < cloDistance) {
                    closest = monstersInRange[i];

                    //Flip to face enemy
                    if (closest.transform.position.x > transform.position.x) {
                        rcCharacter.flipPlayerRight ();
                    } else if (closest.transform.position.x < transform.position.x) {
                        rcCharacter.flipPlayerLeft ();
                    }
                }
            }
        }
        return closest;
    }

    //Stop if hit enemy;
    private void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Monsters") {
            Debug.Log("STOPPP");
            rcCharacter.stop();
        }
    }
}