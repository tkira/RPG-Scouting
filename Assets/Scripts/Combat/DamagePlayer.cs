using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public int damage;

    public CharacterStats characterStats;

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player") {
            characterStats = col.gameObject.GetComponent<CharacterStats>();
            if (slashDamageType) {
                characterStats.takeSlashingDamage(damage);
            } else if (pierceDamageType) {
                characterStats.takePiercingDamage(damage);
            } else if (crushDamageType) {
                characterStats.takeCrushingDamage(damage);
            } else if (explosiveDamageType) {
                characterStats.takeExplosiveDamage(damage);
            }
        }
    }
}