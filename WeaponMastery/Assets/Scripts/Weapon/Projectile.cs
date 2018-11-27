using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    public float speed;
    public float range;
    public float damage;

    private Transform player;
    private Vector2 target;

    public Rigidbody2D rb;


    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        rb = GetComponent<Rigidbody2D>();

        Vector2 bulletSpawn = transform.position;
        rb.velocity = (bulletSpawn - target).normalized * -speed;
    }

    void Update() {

        if (range <= 0) {
            DestroyProjectile();
        } else {
            range -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {

            other.gameObject.GetComponent<HealthController>().Health -= damage; 
            DestroyProjectile();
        }
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
