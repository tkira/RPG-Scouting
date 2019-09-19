using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {

    public CharacterStats characterStats;

    public void dealSlashingDamage (float meleeAttack) {
        characterStats.takeSlashingDamage (meleeAttack);
    }

    public void dealPiercingDamage (float meleeAttack) {
        characterStats.takePiercingDamage (meleeAttack);
    }

    public void dealCrushingDamage (float meleeAttack) {
        characterStats.takeCrushingDamage (meleeAttack);
    }

    public void dealExplosiveDamage (float meleeAttack) {
        characterStats.takeExplosiveDamage (meleeAttack);
    }
}