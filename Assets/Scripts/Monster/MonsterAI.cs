 using System.Collections.Generic;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine;

 public class MonsterAI : MonoBehaviour {

     public Transform Player;
     public float moveSpeed;
     public float MinDist;
     public bool inRangeOfPlayer;
     public MonstersStats monStats;
     public bool rangedMonster;
     public bool meleeMonster;

     void Start () {
         attackDelay = false;
     }

     void Update () {

         if (Vector3.Distance (transform.position, Player.position) >= MinDist && !inRangeOfPlayer) {
             transform.position = Vector2.MoveTowards (transform.position, Player.position, moveSpeed * Time.deltaTime);
             inRangeOfPlayer = false;
         }

         if (Vector3.Distance (transform.position, Player.position) >= MinDist) {
             inRangeOfPlayer = false;
         }

         if (Vector3.Distance (transform.position, Player.position) <= MinDist) {
             inRangeOfPlayer = true;

             if (rangedMonster) {
                 attack ();
             } else if (meleeMonster) {
                 attackM ();
             }
         }
     }

     void attackM () {

     }

     bool attackDelay;
     public GameObject bullet;
     public Transform bulletSpawn;
     void attack () {
         if (!attackDelay) {
             attackDelay = true;
             GameObject bulletPro = Instantiate (bullet, bulletSpawn.position, Quaternion.identity);
             bulletPro.gameObject.GetComponent<DamagePlayerRange> ().monsterStats = monStats;
             StartCoroutine (attackDelayTimer ());
         }
     }

     IEnumerator attackDelayTimer () {
         yield return new WaitForSeconds (monStats.attackSpeed);
         attackDelay = false;
     }
 }