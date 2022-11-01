using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject cannon;
    // Start is called before the first frame update
    void Start()
    {
        //Test to create cannon ball
        Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //Code to move back and forth
    }
}
