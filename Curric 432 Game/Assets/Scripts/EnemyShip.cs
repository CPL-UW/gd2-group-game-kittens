using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject cannon;
    int directionY = 1;
    [SerializeField] float lowestY;
    [SerializeField] float highestY;
    [SerializeField] float waitTime;
    [SerializeField] float fireChance;
    // Start is called before the first frame update
    void Start()
    {
        //Test to create cannon ball
        Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(fireShip());
    }

    void FixedUpdate()
    {
        //Code to move back and forth
        if(rb.position.y < lowestY || rb.position.y > highestY) {
            directionY = directionY * -1;
        }

        rb.MovePosition(rb.position + new Vector2(0, -1* directionY) * Time.fixedDeltaTime);
    }

    IEnumerator fireShip() {
        yield return new WaitForSeconds(waitTime);
        if(Mathf.Round(Random.Range(0, fireChance)) == 1) {
            Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        }
        yield return new WaitForSeconds(waitTime);
    }
}
