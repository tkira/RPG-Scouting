using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderUsage : MonoBehaviour
{

    private MonsterTemplates monstersTemplates;
    public bool LadderEnter;
    // Start is called before the first frame update
    void Start()
    {
        LadderEnter = false;
        monstersTemplates = GameObject.FindGameObjectWithTag ("Monsters").GetComponent<MonsterTemplates> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!monstersTemplates.doorClosed && Input.GetKeyDown (KeyCode.Space) && LadderEnter == true) {
            SceneManager.LoadScene("SampleScene");
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
