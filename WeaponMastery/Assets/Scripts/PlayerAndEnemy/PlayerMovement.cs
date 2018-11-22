using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Movement(x,y)

    public float RunSpeed;
    private Vector2 moveVelocity;
    private Vector2 moveInput;

    #endregion
    #region dash

    public float DashSpeed;
    public float DashTime;
    private bool isInDash;

    #endregion

    private Rigidbody2D rb;

    void Start() {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {

        #region Movement(x,y)

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        #endregion

        #region dash

        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Dash());
        }

        #endregion
    }

    private IEnumerator Dash() {
        isInDash = true;
        rb.velocity = moveInput * DashSpeed;
        yield return new WaitForSeconds(DashTime);
        isInDash = false;
    }

    void FixedUpdate() {

        #region Movement(x,y)

        if (!isInDash) {

            rb.MovePosition(rb.position + moveInput * RunSpeed * Time.fixedDeltaTime);
        }

        #endregion
    }
}
