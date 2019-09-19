using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour {

    public MonstersStats monstersStats;

    public void dealSlashingDamage (float meleeAttack) {
        monstersStats.takeSlashingDamage (meleeAttack);
    }

    public void dealPiercingDamage (float meleeAttack) {
        monstersStats.takePiercingDamage (meleeAttack);
    }

    public void dealCrushingDamage (float meleeAttack) {
        monstersStats.takeCrushingDamage (meleeAttack);
    }

    public void dealExplosiveDamage (float meleeAttack) {
        monstersStats.takeExplosiveDamage (meleeAttack);
    }

}