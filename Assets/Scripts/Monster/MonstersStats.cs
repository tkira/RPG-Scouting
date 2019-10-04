using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonstersStats : MonoBehaviour {

    public Transform monsterPosition;

    //Main Stats
    public float maxHealth;
    public float defence;
    public float meleeAttack;
    public float rangeAttack;
    public float attackSpeed;
    public float moveSpeed;

    //Resistances
    public float crushingRes;
    public float slashingRes;
    public float piercingRes;
    public float explosiveRes;

    //Dynamic Stats 
    public float monsterCurrentHealth;

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
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (crushingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }

        //Destroy if no health left 
        if (monsterCurrentHealth <= 0) {
            LootDrop();
            Destroy (gameObject);
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
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (slashingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }

        //Destroy if no health left 
        if (monsterCurrentHealth <= 0) {
            LootDrop();
            Destroy (gameObject);
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
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (piercingRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }

        //Destroy if no health left 
        if (monsterCurrentHealth <= 0) {
            LootDrop();
            Destroy (gameObject);
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
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        } else if (explosiveRes == 0) {
            adjustedDamage = damage - defence;
            //Defence is lower then damage, deal damage
            if (adjustedDamage > 0) {
                monsterCurrentHealth = monsterCurrentHealth - adjustedDamage;
                popupDamge (adjustedDamage);
            }
        }

        //Destroy if no health left 
        if (monsterCurrentHealth <= 0) {
            LootDrop();
            Destroy (gameObject);
        }
    }

    public GameObject popupDam;
    void popupDamge (float dam) {
        GameObject popup = Instantiate (popupDam, transform.position, Quaternion.Euler (Vector3.zero));
        popup.transform.SetParent (GameObject.FindGameObjectWithTag ("CombatUI").transform, false);
        popup.GetComponent<PopupDamageEnemy> ().SetDamage (dam);
    }

    // Start is called before the first frame update
    void Start () {
        //Initial set max health
        monsterCurrentHealth = maxHealth;
    }
  
    // Update is called once per frame
    void Update () {
        
    }

    //------------------------Loot Drop - i couldnt add to other script
    public List<GameObject> Loots;
    public int[] table = { 60, 30, 20 };
    public int total;
    public int randomNumber;
    public Transform LootSpawn;
    
    public void LootDrop()
    {

        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                //award
                GameObject loot = Instantiate(Loots[i], LootSpawn.position, Quaternion.identity);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }


    }
}