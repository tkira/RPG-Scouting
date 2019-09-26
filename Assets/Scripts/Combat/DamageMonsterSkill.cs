using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMonsterSkill : MonoBehaviour {
    public bool slashDamageType;
    public bool pierceDamageType;
    public bool crushDamageType;
    public bool explosiveDamageType;

    public CharacterStats characterStats;
    public MonsterTakeDamage mTd;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    //Deal Damage and deal damage based on type;
    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "MonsterHitbox") {
            mTd = other.gameObject.GetComponent<MonsterTakeDamage> ();
            if (slashDamageType) {
                mTd.dealSlashingDamage (characterStats.abilityPower);
            } else if (pierceDamageType) {
                mTd.dealPiercingDamage (characterStats.abilityPower);
            } else if (crushDamageType) {
                mTd.dealCrushingDamage (characterStats.abilityPower);
            } else if (explosiveDamageType) {
                mTd.dealExplosiveDamage (characterStats.abilityPower);
            }
        }
    }
}