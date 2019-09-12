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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
    }
    public void confirm()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Exit.SetActive(false);
        //Confirm.SetActive(true);
    }
    public void no()
    {
        Resume.SetActive(false);
        Controls.SetActive(false);
        Options.SetActive(false);
        Exit.SetActive(false);
        Time.timeScale = 1;
        //Confirm.SetActive(false);
        //BG.SetActive(false);
        
    }
}
