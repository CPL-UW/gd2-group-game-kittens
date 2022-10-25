using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    public bool canCollect = false;
    SpriteRenderer renderer;

    void Start() {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Pit")) {
            canCollect = true;
            renderer.enabled = true;
            Debug.Log("Carrot can be collected");
        }

        if(collision.gameObject.CompareTag("Player") && canCollect) {
            Destroy(this.gameObject);
            //playerCarrots++;
            Debug.Log("Carrots/Points: +1");
        }
    }
}
