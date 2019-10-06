using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//currecny text manager
public class Currency : MonoBehaviour
{
    public Text currency;
    public int coin;
    public CharacterStats characterStats;

        void Start()
    {
        
    }

    void Update()
    {
        currency.text = characterStats.coins.ToString();

    }
}
