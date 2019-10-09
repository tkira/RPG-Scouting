using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{

    public float
        characterCurrentHealth
        , totalExp
        , expNeedToLvl
        , currentExp
        , currentLvl

        , maxHealth
        , defence
        , meleeAttack
        , abilityPower
        , attackSpeed
        , moveSpeed

        , crushingRes
        , explosiveRes
        , piercingRes

        , currentDamageOutput
        ;
    
    public int coins;

    public PlayerStats(CharacterStats characterStats)
    {
        //Other things need to be added here
        characterCurrentHealth = characterStats.characterCurrentHealth;
        coins = characterStats.coins;
        totalExp = characterStats.totalExp;
        expNeedToLvl = characterStats.expNeedToLvl;
        currentExp = characterStats.currentExp;
        currentLvl = characterStats.currentLvl;

        maxHealth = characterStats.maxHealth;
        defence = characterStats.defence;
        meleeAttack = characterStats.meleeAttack;
        abilityPower = characterStats.abilityPower;
        attackSpeed = characterStats.attackSpeed;
        moveSpeed = characterStats.moveSpeed;

        crushingRes = characterStats.crushingRes;
        explosiveRes = characterStats.explosiveRes;
        piercingRes = characterStats.piercingRes;
    }
}
