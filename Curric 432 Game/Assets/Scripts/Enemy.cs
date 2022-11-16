using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    float distance; //distance between enemy and target
    float distance2; //distance between enemy and target
    int frame = 0;
    // public float aggroRange; //Range between enemy and target for AI
    public GameObject spawn; //Location enemy will go to if not targeting player
    public Transform player; //Player
    public Transform player2; //Player 2
    private int random; //Random number for AI
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    
        random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }

    }

    void FixedUpdate()
    {

        //Checks distance between enemy and target
        
        distance = Vector2.Distance(player.position, transform.position);
        distance2 = Vector2.Distance(player2.position, transform.position);

        if(distance <= distance2) {
            target = player;
        } else {
            target = player2;
        }
    rb.MovePosition((Vector2)transform.position + (moveDirection * _speed * Time.deltaTime));
    }
}
