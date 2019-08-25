using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharacterStats character1;

    public Slider healthBar;

    public Text healthText;

    void Start(){
        healthBar.maxValue = character1.maxHealth;
    }

    public void Update(){
        healthBar.value = character1.characterCurrentHealth;
        healthText.text = character1.characterCurrentHealth.ToString();
    }
}
