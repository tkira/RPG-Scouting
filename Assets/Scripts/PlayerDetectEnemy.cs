using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectEnemy : MonoBehaviour {

    //Bool to disable auto target when player manually target enemy.
    public bool runPlayerDetectEnemyScript = true;

    //DetectRange 
    public float enemyDetectRange = 50;

    public bool inRangeEnemy = false;
    public GameObject closestEnemy = null;
    public float closestDis = 0;

    // Update is called once per frame
    void Update () {
        if (runPlayerDetectEnemyScript) {
            closestEnemy = FindClosestEnemy ();
            if (closestEnemy != null) {
                inRangeEnemy = true;
                closestDis = (closestEnemy.transform.position - this.transform.position).sqrMagnitude;
                Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
            } else {
                inRangeEnemy = false;
            }
        }
    }

    public GameObject FindClosestEnemy () {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        List<GameObject> enemiesInRange = new List<GameObject> ();
        //Get all enemies in range.
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
        //If one enemy, set default
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
                if (curDistance < cloDistance) {
                    closest = enemiesInRange[i];
                }
            }
        }
        return closest;
    }
}