using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPbar : MonoBehaviour
{
    public GameObject btn1, btn2, bp;

    public void openbp()
    {
        btn1.SetActive(false);
        btn2.SetActive(true);
        bp.SetActive(true);
    }
    public void closebp()
    {
        bp.SetActive(false);
        btn2.SetActive(false);
        btn1.SetActive(true);
    }
}
