using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{

    private bool boxNear;
    // Start is called before the first frame update
    private bool move;
    public int direction;
    // 1 = right, 2 = left, 3 = top, 4 = bottom
    public int moveSpeed;
    GameObject box;

    public Vector2 boxTarget;
    void Start()
    {
        boxNear = false;
        move = false;
        box = this.gameObject.transform.parent.gameObject;
        
        boxTarget = box.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space) && boxNear && !move) { //Added !move to prevent double pushes
            switch(direction){
                case 1:
                boxTarget = new Vector3 (box.transform.position.x-1, box.transform.position.y, box.transform.position.z);
                if(boxTarget.x < Camera.main.transform.position.x - 6.5f){ //prevent it exiting the room
                    boxTarget.x =  Camera.main.transform.position.x - 6.5f;
                }
                move = true;
                Debug.Log ("Move Left");

                //boxNear = false;
                break;
                case 2:
                boxTarget = new Vector3 (box.transform.position.x+1, box.transform.position.y, box.transform.position.z);
                if(boxTarget.x > Camera.main.transform.position.x + 6.5f){
                    boxTarget.x =  Camera.main.transform.position.x + 6.5f;
                }
                move = true;         
                Debug.Log ("Move Right");       
                //boxNear = false;
                break;
                case 3:
                boxTarget = new Vector3 (box.transform.position.x, box.transform.position.y-1, box.transform.position.z);
                if(boxTarget.y < Camera.main.transform.position.y - 2f){
                    boxTarget.y =  Camera.main.transform.position.y - 2f;
                }
                move = true;
                Debug.Log ("Move Down");  
                //boxNear = false;
                break;
                case 4:
                boxTarget = new Vector3 (box.transform.position.x, box.transform.position.y+1, box.transform.position.z);
                if(boxTarget.y > Camera.main.transform.position.y + 2f){
                    boxTarget.y =  Camera.main.transform.position.x + 2f;
                }
                move = true;
                Debug.Log ("Move Up");  
                //boxNear = false;
                break;
            }
        }

        if(move == true){
            box.transform.position = Vector2.MoveTowards (box.transform.position, boxTarget , Time.deltaTime);
            if(box.transform.position.x == boxTarget.x && box.transform.position.y == boxTarget.y ){
                move = false;
            }
        }
        else{
            boxTarget = box.transform.position;
        }
        
        


        //Debug.DrawLine (box.transform.position, boxTarget);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("InteractCollider")) {
            boxNear = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("InteractCollider")) {
            boxNear = false;
        }
    }
}
