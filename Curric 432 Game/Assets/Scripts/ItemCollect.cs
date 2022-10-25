using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private int playerCarrots = 0;

    //public Carrot carrot;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.CompareTag("Carrot") && false) {
            Destroy(collision.gameObject);
            playerCarrots++;
            Debug.Log("Carrots/Points:" + playerCarrots);
        }
    }
}
