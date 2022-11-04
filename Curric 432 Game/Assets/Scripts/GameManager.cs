using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Code to manage the game
*/
public class GameManager : MonoBehaviour
{
    public GameObject carrot; //Carrots to spawn
    public int minX; //Min X to spawn (default -11)
    public int maxX; //Max X to spawn (default 11)
    public int minY; //Min Y to spawn (default -7)
    public int maxY; //Max Y to spawn (default 1)

    //Unused
    [SerializeField]
    public int points;

    void Start()
    {
        //Spawns carrots randomly between a range
        for(int i = 0; i < 10; i++)
        {
            //Default spawns from -11 to 11, 1 to -7
            Instantiate(carrot, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Unused
    public void AddPoint() {
        points++;
    }
}
