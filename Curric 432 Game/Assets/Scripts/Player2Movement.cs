using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Script used to for Player
*/
public class Player2Movement : MonoBehaviour
{
    //Movement Key
    public KeyCode Moveforward;
    public KeyCode Movebackward;
    public KeyCode Moveleft;
    public KeyCode Moveright;

    public KeyCode Digkey;
    public KeyCode Smellkey;


    //Character Attributes
    public float moveSpeed;
    public float digSpeed;
    public float smellSpeed;
    public int hearts;

    //Components
    public Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer playerSprite;
    //public Transform playerTransform; Unused

    //Other GameObjects
    public GameObject pit;
    public GameObject smell;
    public GameManager GM;
    public Heart heart;

    //Variables
    Vector2 movement;

    //Variables needed to have a delay for dig function
    float digProgress = 0;
    float digMaxProgress = 2; //Determine how long the space bar should be held
    bool digHeld;
    public digProgressBar digBar;

    //Variables needed for smell cooldown
    float smellProgress = 0;
    float smellMaxProgress = 2; //Determines how long before player can smell again
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
        if (Input.GetKey(Moveforward))
        {
            movement.y = 1;
        }
        else if (Input.GetKey(Movebackward))
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }

        if (Input.GetKey(Moveright))
        {
            movement.x = 1;
        }
        else if (Input.GetKey(Moveleft))
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }


        //Sets animator variables for animations
        animator.SetFloat("SpeedX", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));
        
        //Flips sprite based on direction
        if(movement.x < 0) {
            playerSprite.flipX = true;
        } else if(movement.x > 0) {
            playerSprite.flipX = false;
        }

        //Dig Function

        //Sets digHeld to true if key is pressed down
        if(Input.GetKeyDown(Digkey)) {
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
        if(Input.GetKeyUp(Digkey)) {
            //FindObjectOfType<AudioManager>().Play("SandSound");

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
            FindObjectOfType<AudioManager>().Play("DigSound");
        }

        //Fills up progress bar
        smellBar.SetValue(smellProgress);
        smellProgress += Time.deltaTime * smellSpeed;
        

        //If key is pressed and progress bar is above certain threshold, player is able to smell
        if(Input.GetKeyDown(Smellkey) && smellProgress > smellMaxProgress) {
            smellProgress = 0;
            smellBar.SetValue(smellProgress);
            Instantiate(smell, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            
            //FindObjectOfType<AudioManager>().Play("SmellSound");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        //Adds points to player
        if(other.gameObject.CompareTag("Carrot")) {
            SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();
            if(renderer.enabled) {
                GM.AddPoint2();
                FindObjectOfType<AudioManager>().Play("FoundSound");
            }
        }

        if(other.gameObject.CompareTag("Damage")) {
            heart.player2Health--;
            heart.UpdateHearts();

            FindObjectOfType<AudioManager>().Play("DamageSound");

            Debug.Log(heart.player2Health);
        }
        

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

        if (other.gameObject.CompareTag("Enemy"))
        {
            // digSpeed = digSpeed/2;
            digSpeed = 1;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        collision = false;
        if (other.gameObject.CompareTag("Enemy"))
        {
            // digSpeed = digSpeed*2;
            digSpeed = 5;
        }
    }

    //Updates players position (based on inputs) at a fixed rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
