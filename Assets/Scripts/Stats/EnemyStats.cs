using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public Transform enemyPos;

    //Main Stats
    public int maxHealth;
    public int defence;
    public int meleeAttack;
    public int rangeAttack;
    public int attackSpeed;
    public int moveSpeed;
    public int dodge;

    //Resistances
    public int crushingRes;
    public int slashingRes;
    public int piercingRes;
    public int explosiveRes;

    //Dynamic Stats 
    public int enemyCurrentHealth;

    public void takeCrushingDamage (int damage) {
        int adjustedDefence = defence * (crushingRes / 100);
        int adjustedDamage = damage - defence;
        enemyCurrentHealth = enemyCurrentHealth - adjustedDamage;
    }

    public void takeSlashingDamage (int damage) {
        int adjustedDefence = defence * (slashingRes / 100);
        int adjustedDamage = damage - defence;
        enemyCurrentHealth = enemyCurrentHealth - adjustedDamage;
    }

    public void takePiercingDamage (int damage) {
        int adjustedDefence = defence * (piercingRes / 100);
        int adjustedDamage = damage - defence;
        enemyCurrentHealth = enemyCurrentHealth - adjustedDamage;
    }

    public void takeExplosiveDamage (int damage) {
        int adjustedDefence = defence * (explosiveRes / 100);
        int adjustedDamage = damage - defence;
        enemyCurrentHealth = enemyCurrentHealth - adjustedDamage;
    }

    void Start () {
        enemyCurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update () {

    }

}