using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//---SAVE SYSTEM NEEDS TO BE ADDED
public class Menu : MonoBehaviour
{
    private bool pause = false;
    public GameObject Resume;
    public GameObject Controls;
    public GameObject Options;
    public GameObject Return;
    public GameObject Confirm;
    public GameObject BG;
    public int currency;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currency = 10;
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

}
