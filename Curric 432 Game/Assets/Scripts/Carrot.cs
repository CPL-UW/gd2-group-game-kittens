using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    public bool canCollect = false;
    SpriteRenderer renderer;
    public Rigidbody2D rb;

    public GameObject shine;

    void Start() {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Pit")) {
            canCollect = true;
            renderer.enabled = true;
            Debug.Log("Carrot can be collected");
        }

        if(collision.gameObject.CompareTag("Radar")) {
            Debug.Log("Carrot is temporarily revealed");
            Instantiate(shine, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        }

        if(collision.gameObject.CompareTag("Player") && canCollect) {
            Destroy(this.gameObject);
            //playerCarrots++;
            Debug.Log("Carrots/Points: +1");
        }
    }
}
