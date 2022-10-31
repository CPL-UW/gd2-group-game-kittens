using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Script to handle player interacting/colliding with objects
*/
public class ItemCollect : MonoBehaviour
{
    public int playerCarrots = 0; //Unused

    //public Carrot carrot;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        //When player collides with a carrot, they collect the carrot
        if(collision.gameObject.CompareTag("Carrot") && false) {
            Destroy(collision.gameObject);
            playerCarrots++;
            Debug.Log("Carrots/Points:" + playerCarrots);
        }
    }
}
