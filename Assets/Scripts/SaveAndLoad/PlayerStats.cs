using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{

	public float characterCurrentHealth;
    public int coins;

    public PlayerStats(CharacterStats characterStats)
	{
		//Other things need to be added here
		characterCurrentHealth = characterStats.characterCurrentHealth;
        coins = characterStats.coins;
	}
}
