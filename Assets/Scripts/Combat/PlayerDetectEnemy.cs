using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectEnemy : MonoBehaviour {

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
            closestDis = (closestEnemy.transform.position - this.transform.position).sqrMagnitude;
            Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
        } else {
            //set false of no enemies found.
            inRangeEnemy = false;
        }

    }

    public GameObject FindClosestEnemy () {
        //get list if all enemies.
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag ("Monsters");

        List<GameObject> enemiesInRange = new List<GameObject> ();
        //Get search all enemies in range.
        foreach (GameObject enemy in enemies) {
            float curDistance = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (curDistance < enemyDetectRange) {
                enemiesInRange.Add (enemy);
            }
        }

        //No enemies in range
        if (enemiesInRange.Count == 0) {
            return null;
        }

        //Find the closest enemy in enemiesInRange
        GameObject closest = null;
        //If one enemy, set only enemy
        if (enemiesInRange.Count == 1) {
            closest = enemiesInRange[0];
        } else if (enemiesInRange.Count > 1) {
            //If the is multiple in range sort and find the closest
            for (int i = 1; i < enemiesInRange.Count; i++) {
                //Set first enemy
                if (closest == null) {
                    closest = enemiesInRange[0];
                }
                float cloDistance = (closest.transform.position - this.transform.position).sqrMagnitude;
                float curDistance = (enemiesInRange[i].transform.position - this.transform.position).sqrMagnitude;
                //compare current enemy with another and set if closer.
                if (curDistance < cloDistance) {
                    closest = enemiesInRange[i];
                    
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
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Monsters") && inRangeEnemy == true) {
            rcCharacter.targetPosition = transform.position;
        }
    }
}