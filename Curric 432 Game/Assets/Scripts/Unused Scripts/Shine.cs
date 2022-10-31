using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unused script
public class Shine : MonoBehaviour
{
    public GameObject smell;
    public int lifeTime;

    void Start()
    {
        Destroy(smell, lifeTime);
    }
}
