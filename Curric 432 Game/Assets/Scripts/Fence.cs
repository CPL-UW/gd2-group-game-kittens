using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float prob; //0 is all fences shown, 100 is almost no fences shown

    [SerializeField] private GameObject[] fence;
    // Start is called before the first frame update
    void Start()
    {
        RandomlyShow();
    }

    void RandomlyShow() {
        float random = 0;
        for(int i = 0; i < fence.Length; i++) {
            random = Mathf.Round(Random.Range(0, 100));
            if(random >= prob) {
                Destroy(fence[i]);
            }
        }

    }

}
