using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smell : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public GameObject smell;

    //public Rigidbody2D rb;

    public int lifeTime;

    void Start()
    {
        //smell.transform.SetParent(player.transform);
        Destroy(smell, lifeTime);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        smell.transform.position = player.transform.position;
    }
    */
}
