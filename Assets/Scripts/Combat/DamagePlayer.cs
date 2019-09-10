using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public MonstersStats monsterStats;
    public CharacterStats characterStats;

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player") {
            characterStats = col.gameObject.GetComponent<CharacterStats>();
            if (slashDamageType) {
                characterStats.takeSlashingDamage(monsterStats.meleeAttack);
            } else if (pierceDamageType) {
                characterStats.takePiercingDamage(monsterStats.meleeAttack);
            } else if (crushDamageType) {
                characterStats.takeCrushingDamage(monsterStats.meleeAttack);
            } else if (explosiveDamageType) {
                characterStats.takeExplosiveDamage(monsterStats.meleeAttack);
            }
        }
    }
}