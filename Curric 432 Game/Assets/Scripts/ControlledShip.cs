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
    [SerializeField] float waitTime;
    [SerializeField] float fireChance;
    [SerializeField] private KeyCode fireKey;
    float power = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D cannon;
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
        if(Input.GetKeyUp(fireKey)) {
            cannon = Instantiate(cannon, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation) as Rigidbody2D;
            //cannon.AddForce(5);
            cannon.AddForce(new Vector3(1, 1, 0) * 5, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(waitTime);
    }
}
