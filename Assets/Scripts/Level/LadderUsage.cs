using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderUsage : MonoBehaviour {

    private MonsterTemplates monstersTemplates;
    public bool LadderEnter;
    public GlobalVariablesController gvc;
    public CharacterStats cs;
    // Start is called before the first frame update
    void Start () {
        LadderEnter = false;
        monstersTemplates = GameObject.FindGameObjectWithTag ("Monsters").GetComponent<MonsterTemplates> ();
        gvc = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariablesController> ();
        cs = GameObject.Find ("Player").GetComponent<CharacterStats> ();
    }

    // Update is called once per frame
    void Update () {
        if (!monstersTemplates.doorClosed && Input.GetKeyDown (KeyCode.Space) && LadderEnter == true) {
            gvc.maxHealth = cs.characterCurrentHealth;
            gvc.lvlcounter = gvc.lvlcounter + 1;
            if(gvc.lvlcounter == 3){
                SceneManager.LoadScene ("TreasureRoom");
            }
            else{
                SceneManager.LoadScene ("Dungeon");
            }
            
        }
    }

    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag ("PlayerHitbox")) {
            LadderEnter = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {

        if (other.CompareTag ("PlayerHitbox")) {
            LadderEnter = false;
        }
    }
}