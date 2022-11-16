using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private float prob;
    [SerializeField] private GameObject[] fence;
    // Start is called before the first frame update
    void Start()
    {
        RandomlyShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomlyShow() {
        float random = 0;
        for(int i = 0; i < fence.Length; i++) {
            random = Mathf.Round(Random.Range(0, 5));
            if(random >= prob) {
                Destroy(fence[i]);
            }
        }

    }

}
