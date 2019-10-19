using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour {

    public bool skillRunning;
    public int skillTime;
    public int cooldown;
    public Transform playerPos;
    public Rigidbody2D playe2d;
    public float dashPower;
    public RightClick rc;
    Ray ray;
    Vector2 targetPosition;
    public CharacterStats charstats;
    public Animator m_Animator;
    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
    }

    public void runSkill () {
        if (!skillRunning) {
            StartCoroutine (SkillAnimation ());
        }
    }

    IEnumerator SkillAnimation () {
        playe2d.velocity = Vector3.zero;
        float normalSpeed = charstats.moveSpeed;
        float attackkSpeedss = charstats.attackSpeed;
        charstats.attackSpeed = 0.5f;
        charstats.moveSpeed = charstats.moveSpeed * 3;
        m_Animator.speed = 3;
        //playe2d.AddForce (targetPosition * dashPower, ForceMode2D.Impulse);
        skillRunning = true;
        yield return new WaitForSeconds (skillTime);
        skillRunning = false;
        charstats.moveSpeed = normalSpeed;
        charstats.attackSpeed = attackkSpeedss;
        m_Animator.speed = 1;
        //playe2d.velocity = Vector3.zero;
        //rc.stop ();
    }
}