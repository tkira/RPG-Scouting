using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFilling : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject boxinHole;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {

    if(other.CompareTag ("Hole")) {
        //Destroy(other.gameObject);
        //Destroy(this.gameObject);
    }
    }

    // void OnCollisionEnter2D (Collision2D collision){
    //     Debug.Log ("Maybe Collide");  
    //     if(collision.gameObject.tag == "Hole") {
    //         Debug.Log ("Collide");  
    //         Instantiate (boxinHole, this.gameObject.transform.position, Quaternion.identity);
    //         Destroy(collision.gameObject);
    //         Destroy(this.gameObject);
    //     }
    // }
}
