using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerRange : MonoBehaviour {
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
                characterStats.takeSlashingDamage(monsterStats.rangeAttack);
            } else if (pierceDamageType) {
                characterStats.takePiercingDamage(monsterStats.rangeAttack);
            } else if (crushDamageType) {
                characterStats.takeCrushingDamage(monsterStats.rangeAttack);
            } else if (explosiveDamageType) {
                characterStats.takeExplosiveDamage(monsterStats.rangeAttack);
            }
        }
    }
}