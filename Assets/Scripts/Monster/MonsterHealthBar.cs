using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthBar : MonoBehaviour {

	Vector3 localScale;
	public MonstersStats monStats; 
	public float Xscale;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float scale = Xscale / 100;
		float curHealth = (monStats.monsterCurrentHealth / monStats.maxHealth) * 100;
		float currentPercent = scale * curHealth;
		localScale.x = currentPercent;
		transform.localScale = localScale;
	}
}
