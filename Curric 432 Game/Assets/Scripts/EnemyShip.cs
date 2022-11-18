using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject cannon;
    public Rigidbody2D cannonTest;
    Rigidbody2D cannonInstance;
    int directionY = 1;
    [SerializeField] float lowestY;
    [SerializeField] float highestY;
    [SerializeField] float waitTime;
    [SerializeField] float fireChance;
    float power;

    // Start is called before the first frame update
    void Start()
    {
        //Test to create cannon ball
        //Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);



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
            //power = Random.Range(3, 10);
            Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            //cannonInstance = Instantiate(cannon, new Vector2(rb.position.x, rb.position.y), transform.rotation) as Rigidbody2D;
            //cannonInstance.AddForce(new Vector2(1, 1) * power, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(waitTime);
    }
}
