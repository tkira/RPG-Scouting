using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonsters : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public CharacterStats charStats;
    public MonstersStats monsterStats;

    public GameObject popupDam;

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Monsters") {
            monsterStats = col.gameObject.GetComponent<MonstersStats> ();

            GameObject popup = Instantiate (popupDam, monsterStats.monsterPosition.position, Quaternion.Euler (Vector3.zero));
            popup.transform.SetParent (GameObject.FindGameObjectWithTag ("CombatUI").transform, false);
            popup.GetComponent<PopupDamageEnemy> ().SetDamage (charStats.currentDamageOutput);
            
            if (slashDamageType) {
                monsterStats.takeSlashingDamage (charStats.currentDamageOutput);
            } else if (pierceDamageType) {
                monsterStats.takePiercingDamage (charStats.currentDamageOutput);
            } else if (crushDamageType) {
                monsterStats.takeCrushingDamage (charStats.currentDamageOutput);
            } else if (explosiveDamageType) {
                monsterStats.takeExplosiveDamage (charStats.currentDamageOutput);
            }
        }
    }
}