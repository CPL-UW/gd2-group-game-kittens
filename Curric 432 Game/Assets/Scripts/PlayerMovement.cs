using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject pit;
    public GameObject smell;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject new_pit = Instantiate(pit, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation) as GameObject;
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            Instantiate(smell, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
