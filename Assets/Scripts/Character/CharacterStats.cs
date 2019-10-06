using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour {

    public Transform characterPos;
    public HealthBar healthbar;
    public Menu menu;
    public MonstersStats monstersStats;
    //Currency
    public int coins;
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
    public float currentDamageOutput;

    //Save

    public void SavePlayer()
    {
        SaveManager.Save(this);
    }
    public void LoadPlayer()
    {
        PlayerStats stats = SaveManager.Load();
        characterCurrentHealth = stats.characterCurrentHealth;
        coins = stats.coins;
    }

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
                popupDamge (adjustedDamage);
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }
    }

    public void takeSlashingDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * slashingRes;
        //Check of is weak or strong against.
        if (slashingRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (slashingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }
    }

    public void takePiercingDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * piercingRes;
        //Check of is weak or strong against.
        if (piercingRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (piercingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }
    }

    public void takeExplosiveDamage (float damage) {
        float adjustedDefence = 0;
        float adjustedDamage = 0;

        float defenceAdded = defence / 100 * explosiveRes;
        //Check of is weak or strong against.
        if (explosiveRes > 0) {
            adjustedDefence = defence + defenceAdded;
            adjustedDamage = damage - adjustedDefence;
            //Defence Higher then damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (explosiveRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                characterCurrentHealth = characterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }
    }

    public void healToFull () {
        characterCurrentHealth = maxHealth;
        popupDamge (maxHealth);
    }

    public GlobalVariablesController gvc;

    // Start is called before the first frame update
    void Start () {
        
        if (SceneManager.GetActiveScene ().name == "Dungeon") {
            //Get Tranfered character stats
            gvc = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariablesController> ();
            currentLvl = gvc.currentLvl;
            currentExp = gvc.currentExp;
            expNeedToLvl = gvc.expNeedToLvl;
            totalExp = gvc.totalExp;
            vitality = gvc.vitality;
            maxHealth = gvc.maxHealth;
            defence = gvc.defence;
            meleeAttack = gvc.meleeAttack;
            rangeAttack = gvc.rangeAttack;
            attackSpeed = gvc.attackSpeed;
            moveSpeed = gvc.moveSpeed;
            abilityPower = gvc.abilityPower;
            dodge = gvc.dodge;
            crushingRes = gvc.crushingRes;
            slashingRes = gvc.slashingRes;
            piercingRes = gvc.piercingRes;
            explosiveRes = gvc.explosiveRes;
            coins = gvc.coins;
        }
        //Initial set max health
        characterCurrentHealth = maxHealth;
        
        //Current Damage is Melee to be added later for diferent swap  damage;
        currentDamageOutput = meleeAttack;
    }

    // Update is called once per frame
    void Update () {
       
        Debug.Log(coins);
        if (characterCurrentHealth <= 0) {
            Destroy (gameObject);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SavePlayer();
            coins += 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadPlayer();
        }
        
        //if (coinScript.currency > 1) {
        //        coins += (coinScript.currency - (coinScript.currency - 1));
        //}

    }

    public GameObject popupDam;
    void popupDamge (float dam) {
        GameObject popup = Instantiate (popupDam, transform.position, Quaternion.Euler (Vector3.zero));
        popup.transform.SetParent (GameObject.FindGameObjectWithTag ("CombatUI").transform, false);
        popup.GetComponent<PopupDamageEnemy> ().SetDamage (dam);
    }
}