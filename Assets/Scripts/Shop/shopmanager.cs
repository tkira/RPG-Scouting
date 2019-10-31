using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class shopmanager : MonoBehaviour
{
    
    public GameObject icon, shop, menuitem, diamond, title, price, buy, money;
    public bool trigger,pressed;
    int i = 322;
    string dummy;
        



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapons")
        {
            icon.SetActive(true);
            trigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapons")
        {
            icon.SetActive(false);
            trigger = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && trigger == true)
        {
            shop.SetActive(true);
            menuitem.SetActive(false);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            shop.SetActive(false);
        }
        
        //if(pressed == true)
        //{
        //    diamond.GetComponentInChildren<TextMeshProUGUI>().text = "Ask For Help";
        //}
    }

    public void back()
    {
        shop.SetActive(false);
        menuitem.SetActive(true);
        Time.timeScale = 1;
        buy.SetActive(false);
    }

    public void AC130()
    {
        
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "$2.50" ;
        title.GetComponentInChildren<TextMeshProUGUI>().text = "AC130";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "Call in a AC130 during combat to rain hell";
    }
    public void minecraft()
    {
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "$392.00";
        title.GetComponentInChildren<TextMeshProUGUI>().text = "Diamond Sword";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "diamond sword. Swords are weapons that are primarily used to kill mobs or players (if multiplayer PvP is on) quicker than with just your character's bare hands.";
    }
    public void rick()
    {
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "$0.20";
        title.GetComponentInChildren<TextMeshProUGUI>().text = "Portal Gun";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "designed to place two portals that objects can pass through.";
    }
    public void jugg()
    {
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "15-killstreak";
        title.GetComponentInChildren<TextMeshProUGUI>().text = "Juggernaut";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "Call in a Juggernaut Suit during combat which will protect you from explosive ordnance disposal armor, requiring excessive amounts of damage to kill.";
    }
    public void realsword()
    {
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "$19.99";
        title.GetComponentInChildren<TextMeshProUGUI>().text = "Diamond Sword Pro";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "Actual sword";
    }
    public void diamong()
    {
        buy.SetActive(true);
        price.GetComponentInChildren<TextMeshProUGUI>().text = "$100,000.00";
        title.GetComponentInChildren<TextMeshProUGUI>().text = "ICED out 2-tone Patek";
        diamond.GetComponentInChildren<TextMeshProUGUI>().text = "While in combat give a flick of the wrist and blind the enemey for 1.3 seconds";
    }
    public void buyitem()
    {
        i -= 10;
        dummy = i.ToString();
        money.GetComponentInChildren<TextMeshProUGUI>().text = "$"+dummy;
        
    }

}
