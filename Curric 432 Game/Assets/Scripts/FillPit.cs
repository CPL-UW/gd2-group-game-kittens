using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPit : MonoBehaviour
{
    private GameObject pit;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pit"))
        {
            DestroyImmediate(pit);
            //GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
