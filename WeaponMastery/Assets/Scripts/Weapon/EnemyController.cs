using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float Speed;

    private Transform target;

	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, target.position) > 1.5){
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
	}
}
