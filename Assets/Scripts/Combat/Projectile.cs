﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject[] playersss;
    public List<GameObject> players;
    public GameObject playr;

    void Start () {
        players = new List<GameObject> ();
        playersss = GameObject.FindGameObjectsWithTag ("Player");

        foreach (GameObject pl in playersss) {
            players.Add (pl);
        }

        if (players.Count == 1) {
            playr = players[0];
        } else if (players.Count > 1) {
            //If the is multiple in range sort and find the closest
                    playr = players[1];
        }

        player = playr.transform;

        target = new Vector2 (player.position.x, player.position.y);

        // Calculate the distance between the destination and the farmer.
        Vector3 distance = player.position - transform.position;

        // Calculate the angle between them.
        float angle = Mathf.Atan2 (distance.y, distance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

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