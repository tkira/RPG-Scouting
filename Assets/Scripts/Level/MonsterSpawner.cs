using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private bool spawned;
    public bool doorClosed;
    private MonsterTemplates monstersTemplates;
    
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        monstersTemplates = GameObject.FindGameObjectWithTag ("Monsters").GetComponent<MonsterTemplates> ();
    }

    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag ("PlayerHitbox") && !spawned) {

            int rand = Random.Range (0, 4);
            int rand2 = Random.Range (0, monstersTemplates.monsters.Length);
            if (rand == 0) {
                Debug.Log ("Spawn Monster");
                Instantiate (monstersTemplates.monsters[rand2], new Vector3 (transform.position.x + 3.5f, transform.position.y + 1.5f, 0), Quaternion.identity);
            }

            rand = Random.Range (0, 4);
            rand2 = Random.Range (0, monstersTemplates.monsters.Length);
            if (rand == 0) {
                Debug.Log ("Spawn Monster");
                Instantiate (monstersTemplates.monsters[rand2], new Vector3 (transform.position.x - 3.5f, transform.position.y - 1.5f, 0), Quaternion.identity);
            }

            rand = Random.Range (0, 4);
            rand2 = Random.Range (0, monstersTemplates.monsters.Length);
            if (rand == 0) {
                Debug.Log ("Spawn Monster");
                Instantiate (monstersTemplates.monsters[rand2], new Vector3 (transform.position.x + 3.5f, transform.position.y - 1.5f, 0), Quaternion.identity);
            }

            rand = Random.Range (0, 4);
            rand2 = Random.Range (0, monstersTemplates.monsters.Length);
            if (rand == 0) {
                Debug.Log ("Spawn Monster");
                Instantiate (monstersTemplates.monsters[rand2], new Vector3 (transform.position.x - 3.5f, transform.position.y + 1.5f, 0), Quaternion.identity);
            }

            spawned = true;
        }
    }

}
