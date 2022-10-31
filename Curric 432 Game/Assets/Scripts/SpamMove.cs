using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpamMove: MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject pit;
    public GameObject smell;

    Vector2 movement;

    //Variables needed to have a cooldown for dig function a
    public float digProgress;
    public float digMaxProgress;
    bool digHeld;
    public digProgressBar digBar;
    private bool collision;
    private new Collider2D collider;
    void Start()
    {
        collision = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedX", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));

        // Old Dig

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collider != null && collider.gameObject != null && collision)
            {
                Destroy(collider.gameObject);
                collision = false;
            }
            else
            {
                animator.Play("Rabbit_Dig");
                Instantiate(pit, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if(other.gameObject.name == "Pit Variant" || other.gameObject.name == "Pit Variant(Clone)")
        {
            collision = true;
            collider = other;

        }
        else
        {
            collision = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("trigger exit");
        collision = false;
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
