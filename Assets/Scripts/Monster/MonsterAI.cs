 using System.Collections.Generic;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine;

 public class MonsterAI : MonoBehaviour {

     public Transform Player;
     public float moveSpeed;
     public float MinDist;     public float MaxDist;
     public bool inRangeOfPlayer;
     public MonstersStats monStats;
     public bool rangedMonster;
     public bool meleeMonster;
     Vector3 setScale;

     void Start () {
         attackDelay = false;
         setScale = transform.localScale;
         Player = GameObject.FindGameObjectWithTag ("Player").transform;
     }

     void Update () {

         //Face Right
         if (Player.position.x > transform.position.x) {
             //Flip Character
             transform.localScale = new Vector3 (setScale.x, setScale.y, setScale.z);
             //Face Left
         } else if (Player.position.x < transform.position.x) {
             //Flip Character
             transform.localScale = new Vector3 (-setScale.x, setScale.y, setScale.z);

         }

         if (Vector3.Distance (transform.position, Player.position) >= MinDist && !inRangeOfPlayer && Vector3.Distance (transform.position, Player.position) <= MaxDist) {
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

     public GameObject meleeAttackHitbox;

     void attackM () {
         if (!attackDelay) {
             attackDelay = true;
             meleeAttackHitbox.SetActive (true);
             StartCoroutine (meleeDelays ());
         }
     }

     IEnumerator meleeDelays () {
         yield return new WaitForSeconds (0.5f);
         meleeAttackHitbox.SetActive (false);
         StartCoroutine (attackDelayTimer ());
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