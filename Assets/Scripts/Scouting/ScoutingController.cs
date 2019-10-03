using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoutingController : MonoBehaviour
{

    public int scoutingLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoDungeon (){
        SceneManager.LoadScene("Dungeon");
    }
}
