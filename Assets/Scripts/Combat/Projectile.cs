using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {
    public float speed;
    private Transform player;
    private Vector2 target;

    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        target = new Vector2 (player.position.x, player.position.y);

        // Calculate the distance between the destination and the farmer.
        Vector3 distance = player.position - transform.position;

        // Calculate the angel between them.
        float angle = Mathf.Atan2 (distance.y, distance.x);

        // Make the angle a bit larger.
        angle *= 20;
        // And round it to zero if it's too small.
        if (Mathf.Abs (angle) < 1)
            angle = 0;
        transform.rotation = Quaternion.Euler (0f, 0f, angle);
    }

    void Update () {
        //Go towards player last postion
        transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
        //Destroy upon reaching
        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile ();
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        //If hit, destroy
    }

    void DestroyProjectile () {
        Destroy (gameObject);
    }
}