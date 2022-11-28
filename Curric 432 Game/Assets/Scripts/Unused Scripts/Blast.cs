using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        //When carrot collides with a pit, carrot can be collected and is rendered
        if(collision.gameObject.CompareTag("Player")) {
            Debug.Log("Player has been hit");
        }
        if(collision.gameObject.CompareTag("Player2")) {
            Debug.Log("Player has been hit");
        }
    }
}
