using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//---SAVE SYSTEM NEEDS TO BE ADDED
public class Menu : MonoBehaviour
{
    private bool pause = false;
    public GameObject Resume, backpack, backpack1, backpack2;
    public GameObject Controls;
    public GameObject Options;
    public GameObject Return;
    public GameObject Confirm;
    public GameObject BG;
    public CharacterStats cs;
    // Update is called once per frame
    void Start()
    {
        cs.LoadPlayer();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (pause)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            //pause = !pause;

            Resume.SetActive(true);
            Controls.SetActive(true);
            Options.SetActive(true);
            Return.SetActive(true);
            BG.SetActive(true);
            Confirm.SetActive(false);
            Debug.Log("zzzzzzzzzzzzzzzzzzzzzzz");
        }

    }


    public void Town()
    {
        SceneManager.LoadScene("Town");
        Time.timeScale = 1;
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void Ingamemenu()
    {
        SceneManager.LoadScene("Ingamemenu");
    }
    
    public void Dungeon()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Bar()
    {
        SceneManager.LoadScene("Bar");
    }
    public void Blacksmith()
    {
        SceneManager.LoadScene("Blacksmith");
    }

    public void confirm()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Return.SetActive(false);
        Confirm.SetActive(true);
    }
    public void no()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Return.SetActive(false);
        Confirm.SetActive(false);
        BG.SetActive(false);
     

        Time.timeScale = 1;
    }

    public void backPackopen()
    {
        backpack.SetActive(true);
        Time.timeScale = 0;
        backpack1.SetActive(false);
        backpack2.SetActive(true);
    }
    public void backPackclose()
    {
        backpack.SetActive(false);
        Time.timeScale = 1;
        backpack1.SetActive(true);
        backpack2.SetActive(false);
    }




}
