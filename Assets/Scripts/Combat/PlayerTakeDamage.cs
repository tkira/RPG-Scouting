using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {

    GameObject player; //Added for broken floor functionality

    public CharacterStats characterStats;

    private GameObject mapPlayer;


    void Start() //broken floor functionality
    {
        player = GameObject.FindGameObjectWithTag ("Player"); //Matt added this
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
        if (other.CompareTag ("BrokenFloor")) { //Matt added this
            mapPlayer = GameObject.FindGameObjectWithTag ("MapPlayer");
            player.transform.position = new Vector3 (0, 0, 0);
            Camera.main.transform.position = new Vector3 (0, 0, -10);
            mapPlayer.transform.localPosition = new Vector3(5.5f , 3, 0);
        }
    }
}