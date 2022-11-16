using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Carrot Code
*/
public class Carrot : MonoBehaviour
{

    //Attributes
    bool canCollect = false;
    //Components
    SpriteRenderer renderer;
    public Rigidbody2D rb;

    //Other objects
    public GameObject shine; //Object to create when carrot is revealed

    void Start() {
        //By default, carrot sprite isn't rendered
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //When carrot collides with a pit, carrot can be collected and is rendered
        if(collision.gameObject.CompareTag("Pit")) {
            canCollect = true;
            renderer.enabled = true;
            Instantiate(shine, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            Debug.Log("Carrot can be collected");
        }

        //When carrot collides with radar, carrot shines
        if(collision.gameObject.CompareTag("Radar")) {
            Debug.Log("Carrot is temporarily revealed");
            Instantiate(shine, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        }

        //When carrot collides with player and is able to be collected, it destroys itself
        if(collision.gameObject.CompareTag("Player") && canCollect) {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Player2") && canCollect) {
            Destroy(this.gameObject);
        }
    }
}
