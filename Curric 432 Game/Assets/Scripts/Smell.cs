using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smell : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject smell;
    public int lifeTime;

    void Start()
    {
        Destroy(smell, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
