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

    public int noBuffs;

    // Start is called before the first frame update
    void Start () {
        //runScoutingRandomiser ();
        gvc = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariablesController> ();
        scoutingLvl = gvc.scoutingLvl;
    }

    public List<string> scoutingEffectsDebuffs = new List<string> ();
    public List<string> scoutingEffectsBuffs = new List<string> ();

    //Debuff vitality;
    void debuffvitality () {
        scoutingEffectsDebuffs.Add ("10% Vitality Reduction");
        float vitality = charstats.vitality - (charstats.vitality * (float) 0.1);
        charstats.vitality = vitality;
    }

    //Debuff Health;
    void debuffmaxHealth () {
        scoutingEffectsDebuffs.Add ("10% Health Reduction");
        float health = charstats.maxHealth - (charstats.maxHealth * (float) 0.1);
        charstats.maxHealth = health;
        charstats.characterCurrentHealth = health;
    }

    //Debuff defence;
    void debuffdefence () {
        scoutingEffectsDebuffs.Add ("10% Defence Reduction");
        float defence = charstats.defence - (charstats.defence * (float) 0.1);
        charstats.defence = defence;
    }

    //Debuff MeleeDamage;
    void debuffmeleeAttack () {
        scoutingEffectsDebuffs.Add ("10% Melee Attack Reduction");
        float attack = charstats.meleeAttack - (charstats.meleeAttack * (float) 0.1);
        charstats.meleeAttack = attack;
    }

    //Debuff RangeDamage;
    void debuffrangeAttack () {
        scoutingEffectsDebuffs.Add ("10% Range Attack Reduction");
        float attack = charstats.rangeAttack - (charstats.rangeAttack * (float) 0.1);
        charstats.rangeAttack = attack;
    }

    //Debuff attackspeed;
    void debuffattackSpeed () {
        scoutingEffectsDebuffs.Add ("10% Attack Speed Reduction");
        float attackSpeed = charstats.attackSpeed - (charstats.attackSpeed * (float) 0.1);
        charstats.attackSpeed = attackSpeed;
    }

    //debuff movespeed;
    void debuffmoveSpeed () {
        scoutingEffectsDebuffs.Add ("10% Movement Speed Reduction");
        float moveSpeed = charstats.moveSpeed - (charstats.moveSpeed * (float) 0.1);
        charstats.moveSpeed = moveSpeed;
    }

    //deBuff abilitypower 
    void debuffabilityPower () {
        scoutingEffectsDebuffs.Add ("10% Ability Power Reduction");
        float attack = charstats.abilityPower - (charstats.abilityPower * (float) 0.1);
        charstats.abilityPower = attack;
    }

    //deBuff dodge 
    void debuffdodge () {
        scoutingEffectsDebuffs.Add ("10% Dodge Reduction");
        float dodge = charstats.dodge - (charstats.dodge * (float) 0.1);
        charstats.dodge = dodge;
    }

    //deBuff crushres 
    void debuffcrushingRes () {
        scoutingEffectsDebuffs.Add ("10% Crush Resistence Reduction");
        float crushingRes = charstats.crushingRes - (charstats.crushingRes * (float) 0.1);
        charstats.crushingRes = crushingRes;
    }

    //deBuff slashingRes 
    void debuffslashingRes () {
        scoutingEffectsDebuffs.Add ("10% Slash Resistence Reduction");
        float slashingRes = charstats.slashingRes - (charstats.slashingRes * (float) 0.1);
        charstats.slashingRes = slashingRes;
    }

    //deBuff piercingRes 
    void debuffpiercingRes () {
        scoutingEffectsDebuffs.Add ("10% Pierce Resistence Reduction");
        float piercingRes = charstats.piercingRes - (charstats.piercingRes * (float) 0.1);
        charstats.piercingRes = piercingRes;
    }

    //deBuff explosiveRes 
    void debuffexplosiveRes () {
        scoutingEffectsDebuffs.Add ("10% Explosion Resistence Reduction");
        float explosiveRes = charstats.explosiveRes - (charstats.explosiveRes * (float) 0.1);
        charstats.explosiveRes = explosiveRes;
    }

    //buff vitality;
    void buffvitality () {
        scoutingEffectsBuffs.Add ("10% Vitality Increase");
        float vitality = charstats.vitality + (charstats.vitality * (float) 0.1);
        charstats.vitality = vitality;
    }

    //buff Health;
    void buffmaxHealth () {
        scoutingEffectsBuffs.Add ("10% Health Increase");
        float health = charstats.maxHealth + (charstats.maxHealth * (float) 0.1);
        charstats.maxHealth = health;
        charstats.characterCurrentHealth = health;
    }

    //buff defence;
    void buffdefence () {
        scoutingEffectsBuffs.Add ("10% Defence Increase");
        float defence = charstats.defence + (charstats.defence * (float) 0.1);
        charstats.defence = defence;
    }

    //buff MeleeDamage;
    void buffmeleeAttack () {
        scoutingEffectsBuffs.Add ("10% Melee Attack Increase");
        float attack = charstats.meleeAttack + (charstats.meleeAttack * (float) 0.1);
        charstats.meleeAttack = attack;
    }

    //buff RangeDamage;
    void buffrangeAttack () {
        scoutingEffectsBuffs.Add ("10% Range Attack Increase");
        float attack = charstats.rangeAttack + (charstats.rangeAttack * (float) 0.1);
        charstats.rangeAttack = attack;
    }

    //buff attackspeed;
    void buffattackSpeed () {
        scoutingEffectsBuffs.Add ("10% Attack Speed Increase");
        float attackSpeed = charstats.attackSpeed + (charstats.attackSpeed * (float) 0.1);
        charstats.attackSpeed = attackSpeed;
    }

    //buff movespeed;
    void buffmoveSpeed () {
        scoutingEffectsBuffs.Add ("10% Movement Speed Increase");
        float moveSpeed = charstats.moveSpeed + (charstats.moveSpeed * (float) 0.1);
        charstats.moveSpeed = moveSpeed;
    }

    //buff abilitypower 
    void buffabilityPower () {
        scoutingEffectsBuffs.Add ("10% Ability Power Increase");
        float attack = charstats.abilityPower + (charstats.abilityPower * (float) 0.1);
        charstats.abilityPower = attack;
    }

    //buff dodge 
    void buffdodge () {
        scoutingEffectsBuffs.Add ("10% Dodge Increase");
        float dodge = charstats.dodge + (charstats.dodge * (float) 0.1);
        charstats.dodge = dodge;
    }

    //buff crushres 
    void buffcrushingRes () {
        scoutingEffectsBuffs.Add ("10% Crush Resistence Increase");
        float crushingRes = charstats.crushingRes + (charstats.crushingRes * (float) 0.1);
        charstats.crushingRes = crushingRes;
    }

    //buff slashingRes 
    void buffslashingRes () {
        scoutingEffectsBuffs.Add ("10% Slash Resistence Increase");
        float slashingRes = charstats.slashingRes + (charstats.slashingRes * (float) 0.1);
        charstats.slashingRes = slashingRes;
    }

    //buff piercingRes 
    void buffpiercingRes () {
        scoutingEffectsBuffs.Add ("10% Pierce Resistence Increase");
        float piercingRes = charstats.piercingRes + (charstats.piercingRes * (float) 0.1);
        charstats.piercingRes = piercingRes;
    }

    //buff explosiveRes 
    void buffexplosiveRes () {
        scoutingEffectsBuffs.Add ("10% Explosion Resistence Increase");
        float explosiveRes = charstats.explosiveRes + (charstats.explosiveRes * (float) 0.1);
        charstats.explosiveRes = explosiveRes;
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

    delegate void BuffsFunctionMethod ();

    public void runScoutingRandomiser () {
        int scoutingLvlPercent = scoutingLvl * 10;

        List<BuffsFunctionMethod> buffsfunction = new List<BuffsFunctionMethod> ();
        List<BuffsFunctionMethod> debuffsfunction = new List<BuffsFunctionMethod> ();
        List<int> buffsActivated = new List<int> ();
        List<int> debuffsActivated = new List<int> ();

        debuffsfunction.Add (debuffvitality);
        debuffsfunction.Add (debuffmaxHealth);
        debuffsfunction.Add (debuffdefence);
        debuffsfunction.Add (debuffmeleeAttack);
        debuffsfunction.Add (debuffrangeAttack);
        debuffsfunction.Add (debuffattackSpeed);
        debuffsfunction.Add (debuffmoveSpeed);
        debuffsfunction.Add (debuffabilityPower);
        debuffsfunction.Add (debuffdodge);
        debuffsfunction.Add (debuffcrushingRes);
        debuffsfunction.Add (debuffslashingRes);
        debuffsfunction.Add (debuffpiercingRes);
        debuffsfunction.Add (debuffexplosiveRes);

        buffsfunction.Add (buffvitality);
        buffsfunction.Add (buffmaxHealth);
        buffsfunction.Add (buffdefence);
        buffsfunction.Add (buffmeleeAttack);
        buffsfunction.Add (buffrangeAttack);
        buffsfunction.Add (buffattackSpeed);
        buffsfunction.Add (buffmoveSpeed);
        buffsfunction.Add (buffabilityPower);
        buffsfunction.Add (buffdodge);
        buffsfunction.Add (buffcrushingRes);
        buffsfunction.Add (buffslashingRes);
        buffsfunction.Add (buffpiercingRes);
        buffsfunction.Add (buffexplosiveRes);

        for (int i = 0; i < noBuffs; i++) {
            int randomNo = Random.Range (0, 100);

            if (randomNo > scoutingLvlPercent) {
                bool notSame = true;
                bool founddebuff = false;

                int randombuff = Random.Range (0, (debuffsfunction.Count - 1));
                debuffsActivated.Add (randombuff);
                debuffsfunction[randombuff] ();
                /*
                                while (notSame) {
                                    int randombuff = Random.Range (0, (debuffsfunction.Count - 1));
                                    //Search for existing
                                    for (int p = 0; p < debuffsActivated.Count - 1; p++) {
                                        if (debuffsActivated[p] == randombuff) {
                                            founddebuff = true;
                                        }
                                    }
                                    if (founddebuff != true) {
                                        debuffsActivated.Add (randombuff);
                                        debuffsfunction[randombuff] ();
                                        notSame = false;
                                        break;
                                    }
                                }
                                */
            } else {
                bool notSame = true;
                bool foundbuff = false;
                int randombuff = Random.Range (0, (buffsfunction.Count - 1));
                buffsActivated.Add (randombuff);
                buffsfunction[randombuff] ();

                /*
                while (notSame) {
                    int randombuff = Random.Range (0, (buffsfunction.Count - 1));
                    //Search for existing
                    for (int p2 = 0; p2 < buffsActivated.Count - 1; p2++) {
                        if (buffsActivated[p2] == randombuff) {
                            foundbuff = true;
                        }
                    }
                    if (foundbuff != true) {
                        buffsActivated.Add (randombuff);
                        buffsfunction[randombuff] ();
                        notSame = false;
                        break;
                    }
                }
                */
            }
        }

    }
}