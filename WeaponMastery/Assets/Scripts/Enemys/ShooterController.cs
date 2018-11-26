using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : EnemyController {

    public float StoppingDistance;
    public float RetreatDistance;
    public float SpottDistance;

    private float timeBtwShots;
    public float StartTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    void Start() {
        timeBtwShots = StartTimeBtwShots;
    }             

    void Update() {
        if (Vector2.Distance(transform.position, target.position) < SpottDistance) {
            if (Vector2.Distance(transform.position, target.position) > StoppingDistance) {

                transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            } else if (Vector2.Distance(transform.position, target.position) < StoppingDistance && Vector2.Distance(transform.position, target.position) > RetreatDistance) {

                transform.position = this.transform.position;
            } else if (Vector2.Distance(transform.position, target.position) < RetreatDistance) {

                transform.position = Vector2.MoveTowards(transform.position, target.position, -Speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0) {

                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet.GetComponent<Projectile>().damage = damage;
                timeBtwShots = StartTimeBtwShots;
            } else {

                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}