using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPressed : MonoBehaviour
{
    private MonsterTemplates monstersTemplates;
    public ButtonCollider[] pressedAll;
    public bool notAll;
    private bool notSpawned;
    // Start is called before the first frame update
    void Start()
    {
        notSpawned = true;
        monstersTemplates = GameObject.FindGameObjectWithTag ("Monsters").GetComponent<MonsterTemplates> ();
    }

    // Update is called once per frame
    void Update()
    {
        pressedAll = GetComponentsInChildren<ButtonCollider>();

        notAll = false;

        for (var i = 0; i < pressedAll.Length; i++){
            if(pressedAll[i].pressed == false){
                notAll = true;
            }
        }
        if(notAll == false && notSpawned){
            Instantiate (monstersTemplates.chest, this.transform.position, Quaternion.identity);
            notSpawned = false;
        }

    }
}
