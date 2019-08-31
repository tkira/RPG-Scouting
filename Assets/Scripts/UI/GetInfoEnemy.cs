using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfoEnemy : MonoBehaviour
{

    public LeftClick leftCick;
    public Text name;

    // Update is called once per frame
    void Update()
    {
        if(leftCick.targetedEnemy != null){
            name.text = leftCick.targetedEnemy.name;
        }
    }
}
