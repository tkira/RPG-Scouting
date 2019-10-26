using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{

    private bool treasureNear;
    public CharacterStats characterStats;
    // Start is called before the first frame update
    private bool moved;
    void Start()
    {
        characterStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();
        treasureNear = false;
        moved = false;
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

    void OnTriggerStay2D (Collider2D other){ //Moves the trasure chest if a puzzle is in the way 
        if (other.CompareTag ("BrokenFloor") && !moved) {
            moved = true;
            transform.position = new Vector3 (transform.position.x-6, transform.position.y+2, transform.position.z);
        }

        if (other.CompareTag ("Hole") && !moved) {
            moved = true;
            transform.position = new Vector3 (transform.position.x-6, transform.position.y+2, transform.position.z);
        }
    }
}
