using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
	Vector2 viewPortSize;
	Camera cam;
    public float viewPortFactor;
    Vector3 targetPostion;
    private Vector3 currentVelocity;
    public float followDuration;
    public float maximumFollowSpeed;
    public Transform player;




    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        viewPortSize = (cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - cam.ScreenToWorldPoint(Vector2.zero)) * viewPortFactor;
        targetPostion = player.position - new Vector3(0,0,10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref currentVelocity, followDuration, maximumFollowSpeed);
    }
    public void OnDrawGizmos()
    {
        Color c = Color.red;
        c.a = 0.3f;
        Gizmos.color = c;
        Gizmos.DrawCube(transform.position, viewPortSize);
    }
}
