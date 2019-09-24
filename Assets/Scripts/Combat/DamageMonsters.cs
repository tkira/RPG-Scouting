using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonsters : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public CharacterStats characterStats;
    public MonsterTakeDamage mTd;
    

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("hit monsters");
        if (other.gameObject.tag == "MonsterHitbox" ) {
            mTd = other.gameObject.GetComponent<MonsterTakeDamage> ();
            if (slashDamageType) {
                mTd.dealSlashingDamage (characterStats.meleeAttack);
            } else if (pierceDamageType) {
                mTd.dealPiercingDamage (characterStats.meleeAttack);
            } else if (crushDamageType) {
                mTd.dealCrushingDamage (characterStats.meleeAttack);
            } else if (explosiveDamageType) {
                mTd.dealExplosiveDamage (characterStats.meleeAttack);
            }
        }
    }
}