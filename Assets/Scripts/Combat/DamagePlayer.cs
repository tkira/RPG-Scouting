using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public CharacterStats characterStats;

    //Deal Damage 
    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log ("Hit Player");
        if (col.gameObject.tag == "Player") {
            if (slashDamageType) {
                characterStats.takeSlashingDamage(100);
            } else if (pierceDamageType) {
                characterStats.takePiercingDamage(100);
            } else if (crushDamageType) {
                characterStats.takeCrushingDamage(100);
            } else if (explosiveDamageType) {
                characterStats.takeExplosiveDamage(100);
            }
        }
    }
}