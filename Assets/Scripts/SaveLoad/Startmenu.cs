using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmenu : MonoBehaviour
{
    public static bool newGame = false, loadGame = false;

    public void loadtrigger()
    {
        loadGame = true;
        SceneManager.LoadScene("Town");
    }
    public void newtrigger()
    {
        SceneManager.LoadScene("Town");
        newGame = true;
    }
}
