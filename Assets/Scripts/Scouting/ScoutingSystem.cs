using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoutingSystem : MonoBehaviour {

    public GlobalVariablesController gvc;
    public int scoutingLvl;
    public CharacterStats charstats;
    public Text buffs;
    public Text debuffs;
    public GameObject scoutingPanel;

    // Start is called before the first frame update
    void Start () {
        gvc = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariablesController> ();
        scoutingLvl = gvc.scoutingLvl;
    }

    public List<string> scoutingEffectsDebuffs = new List<string> ();
    public List<string> scoutingEffectsBuffs = new List<string> ();

    //Debuff Health Min 10%;
    void debuffhealth10 () {
        scoutingEffectsDebuffs.Add ("10% Health Reduction");
        float health = charstats.maxHealth - (charstats.maxHealth * (float) 0.1);
        charstats.maxHealth = health;
        charstats.characterCurrentHealth = health;
    }

    //Debuff MeleeDamage Min 10%;
    void debuffmAttack10 () {
        scoutingEffectsDebuffs.Add ("10% Melee Attack Reduction");
        float attack = charstats.meleeAttack - (charstats.meleeAttack * (float) 0.1);
        charstats.meleeAttack = attack;
    }

    //Buff MeleeDamage Min 10%;
    void buffabilityPower10 () {
        scoutingEffectsBuffs.Add ("10% Ability Power Increase");
        float attack = charstats.abilityPower + (charstats.abilityPower * (float) 0.1);
        charstats.abilityPower = attack;
    }

    //Buff MeleeDamage Min 10%;
    void buffmoveSpeedDouble () {
        scoutingEffectsBuffs.Add ("Double Movement Speed");
        float attack = charstats.moveSpeed * 2;
        charstats.moveSpeed = attack;
    }

    string debuffsString;
    string buffsString;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Z)) {
            if (!scoutingPanel.activeSelf) {
                scoutingPanel.SetActive (true);
                debuffsString = "";
                buffsString = "";
                foreach (string msg in scoutingEffectsDebuffs) {
                    debuffsString = debuffsString + msg + "\n";
                }
                debuffs.text = debuffsString;

                foreach (string msg in scoutingEffectsBuffs) {
                    buffsString = buffsString + msg + "\n";
                }
                buffs.text = buffsString;
            } else {
                scoutingPanel.SetActive (false);
            }
        }
    }
    public void runScoutingRandomiser () {
        debuffhealth10 ();
        debuffmAttack10 ();
        buffabilityPower10();
        buffmoveSpeedDouble();
    }
}