using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userinterface : MonoBehaviour
{
	public Slider HeathBar;

    private void Update()
	{
		if (Input.GetKey(KeyCode.H))
		{
			HeathBar.value -= 0.05f;
		}
	}

}
