using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    public GameObject smell;
    public int lifeTime;

    void Start()
    {
        Destroy(smell, lifeTime);
    }
}
