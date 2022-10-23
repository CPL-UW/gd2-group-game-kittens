using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCarrot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj)
    {
        
        Debug.Log("Collided");
        
    }

}
