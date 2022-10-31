using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int points;

    public Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer playerSprite;

    public GameObject pit;
    public GameObject smell;
    public Transform playerTransform;

    Vector2 movement;

    //Variables needed to have a cooldown for dig function
    public float digProgress;
    public float digMaxProgress;
    bool digHeld;
    public digProgressBar digBar;

    public float smellProgress;
    public float smellMaxProgress;
    public digProgressBar smellBar;

    private bool collision;
    private new Collider2D collider;

    void Start() {
        digBar.SetMaxValue(digMaxProgress);
        digBar.SetValue(0);

        smellBar.SetMaxValue(smellMaxProgress);
        smellBar.SetValue(0);

        collision = false;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedX", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));
        
        if(movement.x < 0) {
            playerSprite.flipX = false;
        } else {
            playerSprite.flipX = true;
        }

        // Old Dig
        /*
        if(Input.GetKeyDown(KeyCode.Space)) {
            animator.Play("Rabbit_Dig");
            GameObject new_pit = Instantiate(pit, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation) as GameObject;
        }
        */

        //Dig but you hold the button down
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (collider != null && collider.gameObject != null && collision)
            {
                Destroy(collider.gameObject);
                collision = false;
            }
            else
            {
                digHeld = true;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space)) {
            digHeld = false;
            digProgress = 0;
            digBar.SetValue(0);
        }

        if(digHeld) {
            digProgress += Time.deltaTime*3;
            digBar.SetValue(digProgress);
            //Prevents Player from moving while digging
            movement.x = 0;
            movement.y = 0;
            //Debug.Log(digProgress);
        }

        if(digProgress > digMaxProgress) {
            animator.Play("Rabbit_Dig");
            GameObject new_pit = Instantiate(pit, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation) as GameObject;
            digHeld = false;
            digProgress = 0;
            digBar.SetValue(0);
        }

        smellBar.SetValue(smellProgress);
        smellProgress += Time.deltaTime;
        

        if(Input.GetKeyDown(KeyCode.R) && smellProgress > smellMaxProgress) {
            smellProgress = 0;
            smellBar.SetValue(smellProgress);
            Instantiate(smell, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            //Debug.Log(playerTransform);
            //Instantiate(smell, transform, false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Carrot")) {
            points++;
        }
        
        if (other.gameObject.name == "Pit Variant" || other.gameObject.name == "Pit Variant(Clone)")
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
        collision = false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
