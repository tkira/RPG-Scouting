using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleFilling : MonoBehaviour
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



    void OnCollisionEnter2D (Collision2D collision){
        //Debug.Log ("Maybe Collide");  
        if(collision.gameObject.tag == "Box") {
            //Debug.Log ("Collide"); 
            Instantiate (boxinHole, this.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }




}
