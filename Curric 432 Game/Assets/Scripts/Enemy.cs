using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    float distance; //distance between enemy and target
    public float aggroRange; //Range between enemy and target for AI
    public GameObject spawn; //Location enemy will go to if not targeting player
    public Transform player; //Player

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

        if(distance <= aggroRange) {
            target = player;
        } else {
            target = spawn.transform;
        }
        rb.MovePosition((Vector2)transform.position + (moveDirection * _speed * Time.deltaTime));
    }
}
