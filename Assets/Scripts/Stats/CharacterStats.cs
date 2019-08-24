using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public Transform characterPos;
    public Slider healthSlider;

    //Level Info
    public int currentLvl;
    public int currentExp;
    public int expNeedToLvl;
    public int totalExp;

    //Main Stats
    public int vitality;
    public int maxHealth;
    public int defence;
    public int meleeAttack;
    public int rangeAttack;
    public int attackSpeed;
    public int moveSpeed;
    public int abilityPower;
    public int dodge;

    //Resistances
    public int crushingRes;
    public int slashingRes;
    public int piercingRes;
    public int explosiveRes;

    //Dynamic Stats 
    public int characterCurrentHealth;

    //Level Up Character
    void levelUp () {
        currentLvl++;

        //Add level up stats 
        maxHealth += 10;

        currentExp -= expNeedToLvl; //Reset Exp bar and keep extra exp
        expNeedToLvl = expNeedToLvl * 2; //Double exp need for next lvl;
    }

    //Add Stats and their Ratios
    public void addVitality () {
        vitality++;
        maxHealth = maxHealth + 5;
    }

    public void addDefence () {
        defence++;
    }

    public void addMeleeAttack () {
        meleeAttack++;
    }

    public void addRangeAttack () {
        rangeAttack++;
    }

    public void addAbilityPower () {
        abilityPower++;
    }

    //Take Damage, adjusted by defence and resistances.
    public void takeCrushingDamage (int damage) {
        int adjustedDefence = defence * (crushingRes / 100);
        int adjustedDamage = damage - defence;
        characterCurrentHealth = characterCurrentHealth - adjustedDamage;
    }

    public void takeSlashingDamage (int damage) {
        int adjustedDefence = defence * (slashingRes / 100);
        int adjustedDamage = damage - defence;
        characterCurrentHealth = characterCurrentHealth - adjustedDamage;
    }

    public void takePiercingDamage (int damage) {
        int adjustedDefence = defence * (piercingRes / 100);
        int adjustedDamage = damage - defence;
        characterCurrentHealth = characterCurrentHealth - adjustedDamage;
    }

    public void takeExplosiveDamage (int damage) {
        int adjustedDefence = defence * (explosiveRes / 100);
        int adjustedDamage = damage - defence;
        characterCurrentHealth = characterCurrentHealth - adjustedDamage;
    }

    // Start is called before the first frame update
    void Start () {
        //Initial set max health
        characterCurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update () {

    }
}