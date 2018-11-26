using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;
    public float damage;
    public float Speed;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
