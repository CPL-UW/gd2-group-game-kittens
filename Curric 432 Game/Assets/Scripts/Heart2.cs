using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart2 : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    // Update is called once per frame
    public void UpdateHearts()
    { 
        for(int i = 0; i < hearts.Length; i++) {
            if (i > playerHealth - 1) {
                hearts[i].color = Color.black;
            }
        }
    }
    
}