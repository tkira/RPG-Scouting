using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {

    GameObject player; //Added for broken floor functionality

    public CharacterStats characterStats;

    void Start() //broken floor functionality
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

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

    void OnTriggerEnter2D (Collider2D other) { //broken floor functionality
        if (other.CompareTag ("BrokenFloor")) {
            player.transform.position = new Vector3 (0, 0, 0);
            Camera.main.transform.position = new Vector3 (0, 0, -10);
        }
    }
}