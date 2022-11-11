using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnKey : MonoBehaviour
{
    public GameObject obj; //Object to despawn
    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)) {
            Destroy(obj);
        }
    }
}
