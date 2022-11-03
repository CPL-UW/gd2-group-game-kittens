using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject cannon;
    public int directionY = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Test to create cannon ball
        Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        //StartCoroutine(fireShip());
    }

    // Update is called once per frame
    void Update()
    {
        //Code to move back and forth
        //rb.MovePosition(new Vector2(0, 1));

        if(rb.position.y < -8 || rb.position.y > 0) {
            directionY = directionY * -1;
        }
        StartCoroutine(fireShip());

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(0, -1* directionY) * Time.fixedDeltaTime);
    }

    IEnumerator fireShip() {
        yield return new WaitForSeconds(3.0f);
        if(Random.Range(0, 1000) == 1) {
            Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            yield return new WaitForSeconds(3.0f);
        }
        yield return new WaitForSeconds(3.0f);
    }
}
