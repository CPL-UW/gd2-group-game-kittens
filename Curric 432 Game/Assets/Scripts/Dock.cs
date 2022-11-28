using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour
{

    public GameManager GM;
    public ControlledShip Ship;
    public GameObject player;
    public GameObject tempLocation;

    public int pointedNeeded;
    

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            if(GM.points % pointedNeeded == 0 && Ship.isControlled == false) {
                Ship.isControlled = true;
                GM.points++; //Gave the player a point so cannon can't be spammed
                Debug.Log("Ship is controlled");
                Ship.numShots = Ship.defaultShots;
                player.transform.position = tempLocation.transform.position;

            }
        }
        
    }

    public void bringPlayer() {
        player.transform.position = this.transform.position;
    }
}
