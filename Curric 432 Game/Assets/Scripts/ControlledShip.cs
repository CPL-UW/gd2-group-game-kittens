using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledShip : MonoBehaviour
{
    public Rigidbody2D rb;

    public Rigidbody2D cannon;
    int directionY = 1;
    [SerializeField] float lowestY;
    [SerializeField] float highestY;
    [SerializeField] private KeyCode fireKey;
    float power;
    bool heldKey = false;

    public bool isControlled;
    public int defaultShots;
    public int numShots;
    //public GameObject dock;

    Rigidbody2D cannonball;

    [SerializeField] float chargeSpeed;
    float progressBar = 0;
    public digProgressBar Bar;

    // Start is called before the first frame update
    void Start()
    {
        numShots = defaultShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Need to add a cool down, a condition for the player to use, and a limit on amount of shots
        // if(isControlled) {
        //     numShots = defaultShots;
        // }


        if(Input.GetKeyDown(fireKey) && isControlled && numShots > 0) {
            heldKey = true;
        }

        if(heldKey) {
            progressBar += Time.deltaTime * chargeSpeed;
            Bar.SetValue(progressBar);
        }

        // if(Input.GetKeyUp(fireKey)) {
        //     heldKey = false;
        //     progressBar = 0;
        //     Bar.SetValue(0);
        // }

        if(Input.GetKeyUp(fireKey) && isControlled && numShots > 0) { //Need to add another condition for when the player controls the ship
            heldKey = false;
            numShots--;

            cannonball = Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation) as Rigidbody2D;
            cannonball.AddForce(new Vector3(1, 1, 0) * 2 * progressBar, ForceMode2D.Impulse);

            progressBar = 0;
            Bar.SetValue(0);
            Debug.Log(numShots + " shots left");
        }

        if(numShots == 0) {
            isControlled = false;
        }
    }

    void FixedUpdate()
    {
        //Code to move back and forth
        if(rb.position.y < lowestY || rb.position.y > highestY) {
            directionY = directionY * -1;
        }
        rb.MovePosition(rb.position + new Vector2(0, -1* directionY) * Time.fixedDeltaTime);
    }


}
