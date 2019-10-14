 using System.Collections.Generic;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine;

 public class MonsterAI : MonoBehaviour {

     public Transform Player;
     public float moveSpeed;
     public float MinDist;
     public float MaxDist;
     public bool inRangeOfPlayer;
     public MonstersStats monStats;
     public bool rangedMonster;
     public bool meleeMonster;
     public bool withTransitionAni;
     public bool transistion;
     Vector3 setScale;
     public Animator monsAni;

     void Start () {
         attackDelay = false;
         setScale = transform.localScale;
         monsAni = gameObject.GetComponent<Animator> ();
     }

     public GameObject[] playersss;
     public List<GameObject> players;
     GameObject playr;
     void Update () {
         players = new List<GameObject> ();
         playersss = GameObject.FindGameObjectsWithTag ("Player");

         foreach (GameObject pl in playersss) {
             players.Add (pl);
         }

         if (players.Count == 1) {
             playr = players[0];
         } else if (players.Count > 1) {
             //If the is multiple in range sort and find the closest
             for (int i = 1; i < players.Count; i++) {
                 //Set first enemy
                 if (playr == null) {
                     playr = players[0];
                 }
                 float cloDistance = (Player.transform.position - transform.position).sqrMagnitude;
                 float curDistance = (players[i].transform.position - transform.position).sqrMagnitude;
                 //compare current enemy with another and set if closer.
                 if (curDistance < cloDistance) {
                     playr = players[i];
                 }
             }
         }

         Player = playr.transform;

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
             monsAni.SetInteger ("MovingType", 1);
         } else if (Vector3.Distance (transform.position, Player.position) <= MinDist) {
             inRangeOfPlayer = true;
             if (rangedMonster) {
                 if (withTransitionAni && !transistion && inRangeOfPlayer) {
                     monsAni.SetInteger ("MovingType", 3);
                     StartCoroutine (transitionDD ());
                     transistion = true;
                 }
                 attack ();
             } else if (meleeMonster) {
                 attackM ();
             }
         } else {
             inRangeOfPlayer = false;
             monsAni.SetInteger ("MovingType", 0);
         }

         if (withTransitionAni && transistion && !inRangeOfPlayer) {
             monsAni.SetInteger ("MovingType", 4);
             transistion = false;
         }
     }

     public GameObject meleeAttackHitbox;

     void attackM () {
         if (!attackDelay) {
             attackDelay = true;
             monsAni.SetInteger ("MovingType", 2);
             //meleeAttackHitbox.SetActive (true);
             StartCoroutine (meleeDelays ());
         }
     }

     IEnumerator transitionDD () {
         yield return new WaitForSeconds (1f);
     }

     IEnumerator meleeDelays () {
         yield return new WaitForSeconds (0.5f);
         //meleeAttackHitbox.SetActive (false);
         monsAni.SetInteger ("MovingType", 0);
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