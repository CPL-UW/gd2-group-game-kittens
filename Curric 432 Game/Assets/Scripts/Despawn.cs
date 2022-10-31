using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Destroys a Game Object after a certain amount of time
*/
public class Despawn : MonoBehaviour
{
    public GameObject obj; //Object to despawn
    public int lifeTime; //Amount of to before despawning

    void Start()
    {
        Destroy(obj, lifeTime);
    }
}
