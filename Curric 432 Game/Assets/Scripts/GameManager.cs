using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Code to manage the game
*/
public class GameManager : MonoBehaviour
{
    public GameObject carrot; //Carrots to spawn
    [SerializeField]
    int numCarrots;
    public int minX; //Min X to spawn (default -11)
    public int maxX; //Max X to spawn (default 11)
    public int minY; //Min Y to spawn (default -7)
    public int maxY; //Max Y to spawn (default 1)

    public PlayerMovement player;
    
    [SerializeField]
    public int points;

    public bool summonChest;
    public GameObject FallingChest;

    public GameObject sparkles;
    

    void Start()
    {
        //SpawnCarrots();
    }

    // Update is called once per frame
    void Update()
    {
        if((points % 10 == 0) && summonChest) {
            Instantiate(FallingChest, new Vector3(0, 9, 0), transform.rotation);
            summonChest = false;
        }
        if((points % 10 == 1) && !summonChest) {
            summonChest = true;
        }
    }

    
    public void AddPoint() {
        points++;
    }

    public void SpawnCarrots() {
        //Spawns carrots randomly between a range
        for(int i = 0; i < numCarrots; i++)
        {
            //Default spawns from -11 to 11, 1 to -7
            Instantiate(carrot, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), transform.rotation);
        }
    }

    public void SparkleScreen() {
        for(int i = 0; i < numCarrots; i++)
        {

            //Default spawns from -11 to 11, 1 to -7
            Instantiate(sparkles, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), transform.rotation);
        }
    }

}
