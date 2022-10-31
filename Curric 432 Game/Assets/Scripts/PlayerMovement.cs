using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Script used to for Player
*/
public class PlayerMovement : MonoBehaviour
{
    //Character Attributes
    public float moveSpeed;
    //public int points; //Unused
    public int digSpeed;

    //Components
    public Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer playerSprite;
    //public Transform playerTransform; Unused

    //Other GameObjects
    public GameObject pit;
    public GameObject smell;

    //Variables
    Vector2 movement;

    //Variables needed to have a delay for dig function
    float digProgress = 0;
    public float digMaxProgress; //Determine how long the space bar should be held
    bool digHeld;
    public digProgressBar digBar;

    //Variables needed for smell cooldown
    float smellProgress = 0;
    public float smellMaxProgress; //Determines how long before player can smell again
    public digProgressBar smellBar;

    // ??
    private bool collision;
    private new Collider2D collider;

    void Start() {

        //Gets Sprite Renderer Component
        playerSprite = GetComponent<SpriteRenderer>();

        //Sets up Progress Bars
        digBar.SetMaxValue(digMaxProgress);
        digBar.SetValue(0);

        smellBar.SetMaxValue(smellMaxProgress);
        smellBar.SetValue(0);

        collision = false;
    }

    void Update()
    {
        //Gets movement inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Sets animator variables for animations
        animator.SetFloat("SpeedX", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));
        
        //Flips sprite based on direction
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

        //Dig Function

        //Sets digHeld to true if key is pressed down
        if(Input.GetKeyDown(KeyCode.Space)) {
            // destroy existing pits if collide
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

        //Sets digHeld to false when key is lifted up
        //Also resets progress
        if(Input.GetKeyUp(KeyCode.Space)) {
            digHeld = false;
            digProgress = 0;
            digBar.SetValue(0);
        }

        //Loads progress bar
        if(digHeld) {
            digProgress += Time.deltaTime * digSpeed;
            digBar.SetValue(digProgress);
            //Prevents Player from moving while digging
            movement.x = 0;
            movement.y = 0;
        }

        //If progress is above a certain threshold, player is able to dig
        if(digProgress > digMaxProgress) {
            animator.Play("Rabbit_Dig");
            Instantiate(pit, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            digHeld = false;
            digProgress = 0;
            digBar.SetValue(0);
        }

        //Fills up progress bar
        smellBar.SetValue(smellProgress);
        smellProgress += Time.deltaTime;
        

        //If key is pressed and progress bar is above certain threshold, player is able to smell
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
        /*
        if(other.gameObject.CompareTag("Carrot")) {
            points++;
        }
        */

        // Check if collide with pits
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

    //Updates players position (based on inputs) at a fixed rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
