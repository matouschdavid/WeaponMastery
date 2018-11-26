using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinterController : EnemyController {

    public GameObject Explosion;

    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 1) {

            Debug.Log("Hit Player");
            target.gameObject.GetComponent<HealthController>().Health -= damage;
            Destroy();
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }
    }
    private void Destroy() {
        Destroy(gameObject);
    }
}


