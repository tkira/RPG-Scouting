using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public Transform characterPos;
    public HealthBar healthbar;

    //Level Info
    public float currentLvl;
    public float currentExp;
    public float expNeedToLvl;
    public float totalExp;

    //Main Stats
    public float vitality;
    public float maxHealth;
    public float defence;
    public float meleeAttack;
    public float rangeAttack;
    public float attackSpeed;
    public float moveSpeed;
    public float abilityPower;
    public float dodge;

    //Resistances
    public float crushingRes;
    public float slashingRes;
    public float piercingRes;
    public float explosiveRes;

    //Dynamic Stats 
    public float characterCurrentHealth;

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

    //Take Damage, adjusted by defence and resistances. Update health bar
    public void takeCrushingDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        //Calculate how much extra defence
        float defenceAdded = defence / 100 * crushingRes;
        //Check of is weak or strong against.
        if (crushingRes > 0) {
            //Adjust Defence Rating
            adjustedDefence = defence + defenceAdded;
            //Reduce the in coming damage with adjustedDefence
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage, deal damage
            //This is to prevent dealing minus damage because of defence higher than damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        }
    }

    public void takeSlashingDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * slashingRes;
        //Check of is weak or strong against.
        if (crushingRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        }
    }

    public void takePiercingDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * piercingRes;
        //Check of is weak or strong against.
        if (crushingRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        }
    }

    public void takeExplosiveDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * explosiveRes;
        //Check of is weak or strong against.
        if (crushingRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
            }
        }
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