using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopmanager : MonoBehaviour
{

    public GameObject icon, shop, menuitem;
    public bool trigger;

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
    }

    public void back()
    {
        shop.SetActive(false);
        menuitem.SetActive(true);
        Time.timeScale = 1;
    }
}
