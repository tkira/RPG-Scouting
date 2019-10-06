﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    
    public int currency;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        
        // Calculate the distance between the destination and the farmer.
        Vector3 distance = player.position - transform.position;
        // Calculate the angle between them.
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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


    void DestroyProjectile()
    {
        Destroy(gameObject);
        
    }
}
