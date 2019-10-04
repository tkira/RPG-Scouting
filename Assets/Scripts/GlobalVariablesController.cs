using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariablesController : MonoBehaviour {

    public int scoutingLvl;

    //CharacterStats
    public float currentLvl;
    public float currentExp;
    public float expNeedToLvl;
    public float totalExp;

    public float vitality;
    public float maxHealth;
    public float defence;
    public float meleeAttack;
    public float rangeAttack;
    public float attackSpeed;
    public float moveSpeed;
    public float abilityPower;
    public float dodge;

    public float crushingRes;
    public float slashingRes;
    public float piercingRes;
    public float explosiveRes;

    // Start is called before the first frame update
    void Start () {
        DontDestroyOnLoad (this.gameObject);
    }

    // Update is called once per frame
    void Update () {

    }
}