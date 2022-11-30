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
            if(GM.points % pointedNeeded == 0 && Ship.isControlled == false && GM.points > 0) {
                Ship.isControlled = true;
                GM.points++; //Gave the player a point so cannon can't be spammed
                Debug.Log("Ship is controlled");
                Ship.numShots = Ship.defaultShots; //Resets the number of cannon balls the player has
                player.transform.position = tempLocation.transform.position; //Moves player offscreen

            }
        }
        
    }

    //Moves player to where dock is
    public void bringPlayer() {
        player.transform.position = this.transform.position;
    }
}
