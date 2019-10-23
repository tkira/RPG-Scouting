using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour {
    //Change Script name to change skill
    public CloneSkill skill1;
    public GameObject skill1Panel;
    bool skill1CooldownB;
    public Text skill1CooldownText;
    public int skill1CurrentCooldown;

    public DashSkill skill2;
    public GameObject skill2Panel;
    bool skill2CooldownB;
    public Text skill2CooldownText;
    public int skill2CurrentCooldown;
    public RightClick rc;
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
        } else if (Input.GetKeyDown (KeyCode.E)) {
            if (!skill2.skillRunning && !skill2CooldownB) {
                skill2.runSkill ();
                skill2CooldownB = true;
                StartCoroutine (skill2StartCountdown ());
            }
        }

        if (skill1CooldownB) {
            skill1Panel.SetActive (true);
        } else {
            skill1Panel.SetActive (false);
        }

        if (skill2CooldownB) {
            skill2Panel.SetActive (true);
        } else {
            skill2Panel.SetActive (false);
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

    public IEnumerator skill2StartCountdown () {
        skill2CurrentCooldown = skill2.cooldown;
        skill2CooldownText.text = skill2CurrentCooldown.ToString ();
        while (skill2CurrentCooldown > 0) {
            yield return new WaitForSeconds (1.0f);
            skill2CurrentCooldown--;
            skill2CooldownText.text = skill2CurrentCooldown.ToString ();
            if (skill2CurrentCooldown == 0) {
                skill2CooldownB = false;
            }
        }
    }
}