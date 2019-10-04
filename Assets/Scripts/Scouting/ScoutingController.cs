using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoutingController : MonoBehaviour {

    public int scoutingLevel;
    public Text scoutingText;
    public GlobalVariablesController GVC;
    public CharacterStats CS;

    // Start is called before the first frame update
    void Start () {
        scoutingLevel = 0;
        scoutingText.text = scoutingLevel.ToString ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void increaseLevel () {
        if (scoutingLevel < 10) {
            scoutingLevel++;
            scoutingText.text = scoutingLevel.ToString ();
        }
    }

    public void decreaseLevel () {
        if (scoutingLevel > 0) {
            scoutingLevel--;
            scoutingText.text = scoutingLevel.ToString ();
        }
    }

    public void gotoDungeon () {
        //Store All Variables for Dungeon
        GVC.scoutingLvl = scoutingLevel;
        GVC.currentLvl = CS.currentLvl;
        GVC.currentExp = CS.currentExp;
        GVC.expNeedToLvl = CS.expNeedToLvl;
        GVC.totalExp = CS.totalExp;
        GVC.vitality = CS.vitality;
        GVC.maxHealth = CS.maxHealth;
        GVC.defence = CS.defence;
        GVC.meleeAttack = CS.meleeAttack;
        GVC.rangeAttack = CS.rangeAttack;
        GVC.attackSpeed = CS.attackSpeed;
        GVC.moveSpeed = CS.moveSpeed;
        GVC.abilityPower = CS.abilityPower;
        GVC.dodge = CS.dodge;
        GVC.crushingRes = CS.crushingRes;
        GVC.slashingRes = CS.slashingRes;
        GVC.piercingRes = CS.piercingRes;
        GVC.explosiveRes = CS.explosiveRes;
        SceneManager.LoadScene ("Dungeon");
    }
}