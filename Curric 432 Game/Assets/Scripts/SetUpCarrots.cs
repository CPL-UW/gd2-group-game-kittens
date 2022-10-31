using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCarrots : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject carrot;

    //Unused
    public int points;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            //Vector3 spawn;
            //spawn.x = Random.Range(-11, 11);
            //spawn.y = Random.Range(-7, 1);

            //-11 to 11, 1 to -7
            Instantiate(carrot, new Vector3(Random.Range(-11, 11), Random.Range(-7, 1), 0), transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint() {
        points++;
    }
}
