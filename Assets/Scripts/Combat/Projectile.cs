using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        //Go towards player last postion
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Destroy upon reaching
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If hit, destroy
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);   
    }
}
