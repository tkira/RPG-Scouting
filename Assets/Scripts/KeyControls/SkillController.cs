using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour {
    //Change Script name to change skill
    public ExplosionSkill skill1;
    public GameObject skill1Panel;
    bool skill1CooldownB;
    public Text skill1CooldownText;
    public int skill1CurrentCooldown;

    public GameObject skill2;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Q)) {
            if (!skill1.skillRunning && !skill1CooldownB) {
                skill1.runSkill ();
                skill1CooldownB = true;
                StartCoroutine (skill1StartCountdown ());
            }
        } else if (Input.GetKeyDown (KeyCode.W)) {
            Debug.Log ("w key was pressed");
        }

        if (skill1CooldownB) {
            skill1Panel.SetActive (true);
        } else {
            skill1Panel.SetActive (false);
        }
    }

    public IEnumerator skill1StartCountdown () {
        skill1CurrentCooldown = skill1.cooldown;
        skill1CooldownText.text = skill1CurrentCooldown.ToString ();
        while (skill1CurrentCooldown > 0) {
            yield return new WaitForSeconds (1.0f);
            skill1CurrentCooldown--;
            skill1CooldownText.text = skill1CurrentCooldown.ToString ();
            if (skill1CurrentCooldown == 0) {
                skill1CooldownB = false;
            }
        }
    }
}