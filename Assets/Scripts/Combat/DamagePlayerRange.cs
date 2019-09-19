using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerRange : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public MonstersStats monsterStats;
    public PlayerTakeDamage pTd;

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "PlayerHitbox") {
            pTd = col.gameObject.GetComponent<PlayerTakeDamage> ();
            if (slashDamageType) {
                pTd.dealSlashingDamage (monsterStats.rangeAttack);
            } else if (pierceDamageType) {
                pTd.dealPiercingDamage (monsterStats.rangeAttack);
            } else if (crushDamageType) {
                pTd.dealCrushingDamage (monsterStats.rangeAttack);
            } else if (explosiveDamageType) {
                pTd.dealExplosiveDamage (monsterStats.rangeAttack);
            }
            Destroy (gameObject);
        }
    }
}