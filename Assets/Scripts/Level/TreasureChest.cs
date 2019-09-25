using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{

    private bool treasureNear;
    public CharacterStats characterStats;
    // Start is called before the first frame update
    void Start()
    {
        characterStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();
        treasureNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space) && treasureNear) {
            characterStats.healToFull();
            Destroy (gameObject);
        }

    }

    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag ("PlayerHitbox")) {
            treasureNear = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {

        if (other.CompareTag ("PlayerHitbox")) {
            treasureNear = false;
        }
    }
}
