using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class Weapons : MonoBehaviour
{

    public GameObject shopicon, shop, bottombar,resume,txt;
    public bool trigger, pressed = false;
    public TextMeshProUGUI textDisplay;
    public string[] sentences_;
    public float typingSpeed;
    public int index;
    

    IEnumerator Type()
    {
        txt.SetActive(true);
        foreach (char letter in sentences_[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapons")
        {
            shopicon.SetActive(true);
            trigger = true;
        }
    }

     void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapons")
        {
            shopicon.SetActive(false);
            trigger = false;
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space) && trigger == true && pressed == false)
        {
            shop.SetActive(true);
            textDisplay.text = "";
            NextSentence();
            bottombar.SetActive(false);
            resume.SetActive(true);
            pressed = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            shop.SetActive(false);
            bottombar.SetActive(true);
            txt.SetActive(false);
            index = 0;
            textDisplay.text = "";
            pressed = false;
        }


    }


    // Start is called before the first frame update
    void Start()
    {

    }


    public void NextSentence()
    {
 
        if (index < sentences_.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        //--- where the dialog ends
        else
        {
            textDisplay.text = "";
            index = 0;
        }

    }


    public void exitshop()
    {
        shop.SetActive(false);
        NextSentence();
        bottombar.SetActive(true);
        txt.SetActive(false);
    }
}
