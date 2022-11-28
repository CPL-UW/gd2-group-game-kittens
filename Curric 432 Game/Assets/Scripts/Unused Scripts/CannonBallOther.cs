using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallOther : MonoBehaviour
{
    float startY;
    public GameObject obj;
    public GameObject blast;

    public Rigidbody2D rb;
    public Collider2D collision;

    public float power; //Default is 7

    //This cannon ball fires towards the left

    // Start is called before the first frame update
    void Start()
    {
        startY = rb.position.y;
        power = Random.Range(3, 10);
        rb.AddForce(new Vector3(-1, 1, 0) * power, ForceMode2D.Impulse);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if(startY > rb.position.y && !(collision.gameObject.CompareTag("Pit"))) {
            Destroy(obj);
            Instantiate(blast, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            //Debug.Log("Blast");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(startY >= rb.position.y && collision.gameObject.CompareTag("Pit")) {
            Debug.Log("Defuse");
            Destroy(obj);
        }
    }
}
