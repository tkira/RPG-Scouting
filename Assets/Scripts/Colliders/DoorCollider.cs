using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DoorCollider : MonoBehaviour {

    public GameObject interactIcon, factoryicon, baricon, ballon;
    public GameObject DoorIcon, shopicon;
    public GameObject camera;
    public bool Ttrigger = false, shop = false;
    public bool Btrigger = false;
    public bool Rtrigger = false;
    public bool Ltrigger = false;
    public bool keyEntered = false;
    //---Town
    public bool Bardoor = false;
    public bool Blacksmithdoor = false;
    public bool Dungeondoor = false;
    public bool Insidebar = false, Insidefactory = false;
    //Enable object if in range

    public RightClick rcPlayer;
    private MonsterTemplates monstersTemplates;
    public GameObject mapPlayer;

    void Start () {
        //Physics2D.IgnoreLayerCollision (8, 9,true);
        monstersTemplates = GameObject.FindGameObjectWithTag ("Monsters").GetComponent<MonsterTemplates> ();
    }

    void OnTriggerEnter2D (Collider2D col) {
        //-----Town door icon/trigger
        if (col.gameObject.tag == "Bardoor" || col.gameObject.tag == "Blacksmithdoor" || col.gameObject.tag == "Dungeondoor" || col.gameObject.tag == "Insidebar" || col.gameObject.tag == "Insidefactory") {
			
			if (col.gameObject.tag == "Bardoor") {
                Bardoor = true;
				baricon.SetActive(true);
            }
            if (col.gameObject.tag == "Insidebar") {
                Insidebar = true;
				interactIcon.SetActive(true);
			}
            if (col.gameObject.tag == "Insidefactory")
            {
                Insidefactory = true;
				interactIcon.SetActive(true);
			}
            if (col.gameObject.tag == "Blacksmithdoor") {
                Blacksmithdoor = true;
				factoryicon.SetActive(true);
            }
            if (col.gameObject.tag == "Dungeondoor") {
                Dungeondoor = true;
				ballon.SetActive(true);
            }
            if (col.gameObject.tag == "weapons") {
                shopicon.SetActive (true);
                shop = true;
            }

        }
        //-----interactable icons
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive (true);
        }

        //-----Door icon & triggers
        if (col.gameObject.tag == "TopDoor" && !monstersTemplates.doorClosed) {
            DoorIcon.SetActive (true);
            if (!keyEntered) {
                Ttrigger = true;
            }
            rcPlayer.stop ();
        }
        if (col.gameObject.tag == "RightDoor" && !monstersTemplates.doorClosed) {
            if (!keyEntered) {
                Rtrigger = true;
            }
            DoorIcon.SetActive (true);
            rcPlayer.stop ();
        }
        if (col.gameObject.tag == "BottomDoor" && !monstersTemplates.doorClosed) {
            if (!keyEntered) {
                Btrigger = true;
            }
            DoorIcon.SetActive (true);
            rcPlayer.stop ();
        }
        if (col.gameObject.tag == "LeftDoor" && !monstersTemplates.doorClosed) {
            if (!keyEntered) {
                Ltrigger = true;
            }
            DoorIcon.SetActive (true);
            rcPlayer.stop ();
        }
    }

    //Disable if exit 
    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Interact") {
            interactIcon.SetActive (false);
        }
        //---- Town door icon/trigger
        if (col.gameObject.tag == "Bardoor" || col.gameObject.tag == "Blacksmithdoor" || col.gameObject.tag == "Dungeondoor" || col.gameObject.tag == "Insidebar" || col.gameObject.tag == "Insidefactory") {
            interactIcon.SetActive (false);

            if (col.gameObject.tag == "Bardoor") {
                Bardoor = false;
				baricon.SetActive(false);
            }
            if (col.gameObject.tag == "Insidebar") {
                Insidebar = false;
            }
            if (col.gameObject.tag == "Insidefactory")
            {
                Insidefactory = false;
            }
            if (col.gameObject.tag == "Blacksmithdoor") {
                Blacksmithdoor = false;
				factoryicon.SetActive(false);
            }
            if (col.gameObject.tag == "Dungeondoor") {
                Dungeondoor = false;
				ballon.SetActive(false);
            }
        }
        //-----Door icon & triggers
        if (col.gameObject.tag == "TopDoor") {
            DoorIcon.SetActive (false);
            if (!keyEntered) {
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
        }
        if (col.gameObject.tag == "RightDoor") {
            if (!keyEntered) {
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
            DoorIcon.SetActive (false);
        }
        if (col.gameObject.tag == "BottomDoor") {
            if (!keyEntered) {
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
            DoorIcon.SetActive (false);
        }
        if (col.gameObject.tag == "LeftDoor") {
            if (!keyEntered) {
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
            DoorIcon.SetActive (false);
        }
        if (col.gameObject.tag == "weapons") {
            shopicon.SetActive (false);
            shop = false;
        }
    }

    Vector3 startPos;
    public float speed;
    // Update is called once per frame

    public GameObject scoutingPanel;

    public void Update () {
        if (Input.GetKeyDown (KeyCode.Space) && !keyEntered) {
            keyEntered = true;
            startPos = camera.transform.position;
            mapPlayer = GameObject.FindGameObjectWithTag ("MapPlayer");
        }
        if (Input.GetKeyDown (KeyCode.Space) && shop == true) {

        }
        //----Town scene change
        if (keyEntered == true) {
            if (Insidebar == true) {
                SceneManager.LoadScene ("Town");
            }
            if (Insidefactory == true)
            {
                SceneManager.LoadScene("Town");
            }
            if (Bardoor == true) {
                SceneManager.LoadScene ("Bar");
            }
            if (Dungeondoor == true) {
                //SceneManager.LoadScene("SampleScene");
                scoutingPanel.SetActive (true);
                Time.timeScale = 0;
            }
            if (Blacksmithdoor == true) {
                SceneManager.LoadScene ("Blacksmith");
            }
        }
        //----
        if (Ttrigger == true && keyEntered == true && !monstersTemplates.doorClosed) {
            FadeIn ();
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x, startPos.y + 9f, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x, startPos.y + 9f, startPos.z)) {
                mapPlayer.transform.position = new Vector3 (mapPlayer.transform.position.x, mapPlayer.transform.position.y + 0.2817f, mapPlayer.transform.position.z);
                rcPlayer.teleportToNewPositionT ();
                FadeOut ();
                keyEntered = false;
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
        } else if (Rtrigger == true && keyEntered == true && !monstersTemplates.doorClosed) {
            FadeIn ();
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x + 16f, startPos.y, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x + 16f, startPos.y, startPos.z)) {
                mapPlayer.transform.position = new Vector3 (mapPlayer.transform.position.x + 0.55f, mapPlayer.transform.position.y, mapPlayer.transform.position.z);
                rcPlayer.teleportToNewPositionR ();
                FadeOut ();
                keyEntered = false;
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
        } else if (Ltrigger == true && keyEntered == true && !monstersTemplates.doorClosed) {
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x - 16f, startPos.y, startPos.z), speed * Time.deltaTime);
            FadeIn ();
            if (camera.transform.position == new Vector3 (startPos.x - 16f, startPos.y, startPos.z)) {
                mapPlayer.transform.position = new Vector3 (mapPlayer.transform.position.x - 0.55f, mapPlayer.transform.position.y, mapPlayer.transform.position.z);
                rcPlayer.teleportToNewPositionL ();
                FadeOut ();
                keyEntered = false;
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
        } else if (Btrigger == true && keyEntered == true && !monstersTemplates.doorClosed) {
            FadeIn ();
            camera.transform.position = Vector3.MoveTowards (camera.transform.position, new Vector3 (startPos.x, startPos.y - 9f, startPos.z), speed * Time.deltaTime);
            if (camera.transform.position == new Vector3 (startPos.x, startPos.y - 9f, startPos.z)) {
                mapPlayer.transform.position = new Vector3 (mapPlayer.transform.position.x, mapPlayer.transform.position.y - 0.2817f, mapPlayer.transform.position.z);
                rcPlayer.teleportToNewPositionB ();
                FadeOut ();
                keyEntered = false;
                Btrigger = false;
                Ltrigger = false;
                Rtrigger = false;
                Ttrigger = false;
            }
        } else {
            keyEntered = false;
        }
    }

    public CanvasGroup uiElement;

    public void unpause () {
        Time.timeScale = 1;
    }
    void FadeIn () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 1, .2f));
    }

    void FadeOut () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup (CanvasGroup cg, float start, float end, float lerpTime) {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true) {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp (start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate ();
        }
        print ("done");
    }

}