using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public MonstersStats monsterStats;
    public PlayerTakeDamage pTd;

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "PlayerHitbox") {
            pTd = col.gameObject.GetComponent<PlayerTakeDamage>();
            if (slashDamageType) {
                pTd.dealSlashingDamage(monsterStats.meleeAttack);
            } else if (pierceDamageType) {
                pTd.dealPiercingDamage(monsterStats.meleeAttack);
            } else if (crushDamageType) {
                pTd.dealCrushingDamage(monsterStats.meleeAttack);
            } else if (explosiveDamageType) {
                pTd.dealExplosiveDamage(monsterStats.meleeAttack);
            }
        }
    }
}