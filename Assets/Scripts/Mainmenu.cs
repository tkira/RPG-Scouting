using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{

    private bool pause = false;
    public GameObject Resume;
    public GameObject Controls;
    public GameObject Options;
    //public GameObject Confirm;
    public GameObject Exit;
    public GameObject savegame;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            trigger = true;
            savegame.SetActive(true);
            Resume.SetActive(true);
            Controls.SetActive(true);
            Options.SetActive(true);
            Exit.SetActive(true);

            if (pause)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && trigger == true)
        //{
        //    trigger = false;
        //    savegame.SetActive(false);
        //    Resume.SetActive(false);
        //    Controls.SetActive(false);
        //    Options.SetActive(false);
        //    Exit.SetActive(false);
        //}
    }

    public void confirm()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Exit.SetActive(false);
        savegame.SetActive(false);
        //Confirm.SetActive(true);
    }
    public void no()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Exit.SetActive(false);
        savegame.SetActive(false);
        Time.timeScale = 1;
        //Confirm.SetActive(false);
        //BG.SetActive(false);
        
    }
    public void exitgame()
    {
        Application.Quit();
    }
}
