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
    int numCarrots; //Number of carrots to spawn
    public int minX; //Min X to randomly spawn (default was -11)
    public int maxX; //Max X to randomly spawn (default was 11)
    public int minY; //Min Y to randomly spawn (default was -7)
    public int maxY; //Max Y to randomly spawn (default was 1)

    //public PlayerMovement player; //unused
    
    public int points; //Points/Number of golden carrots collected
    public int points2; //Points/Number of golden carrots collected

    public bool summonChest; //Whether a chest can spawn or not
    public GameObject FallingChest;

    public GameObject sparkles;

    [SerializeField] private GameObject fence;
    

    void Start()
    {
        //SpawnCarrots();
        SpawnFences();
    }

    // Update is called once per frame
    void Update()
    {
        //Summons a chest if a player obtains 10 points
        if(((points + points2) % 10 == 0) && summonChest) {
            Instantiate(FallingChest, new Vector3(0, 9, 0), transform.rotation);
            summonChest = false;
        }
        if(((points + points2) % 10 == 1) && !summonChest) {
            summonChest = true;
        }
    }

    //Add a point
    public void AddPoint() {
        points++;
    }

    public void AddPoint2() {
        points2++;
    }

    //Randomly spawns golden carrots
    public void SpawnCarrots() {
        //Spawns carrots randomly between a range
        for(int i = 0; i < numCarrots; i++)
        {
            //Default spawns from -11 to 11, 1 to -7
            Instantiate(carrot, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), transform.rotation);
        }
    }

    //Randomly spawns sparkles
    public void SparkleScreen() {
        for(int i = 0; i < numCarrots; i++)
        {
            Instantiate(sparkles, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), transform.rotation);
        }
    }

    //Randomly spawn fences (walls)
    public void SpawnFences() {
        float randX = 0;
        float randY = 0;
        for(int i = 0; i < 5; i++)
        {
            randX = Mathf.Round(Random.Range(minX, maxX));
            randY = Mathf.Round(Random.Range(minY, maxY));
            Instantiate(fence, new Vector3(randX, randY, 0), transform.rotation);
        }
    }

}
