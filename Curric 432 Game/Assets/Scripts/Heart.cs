using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int playerHealth;
    public int player2Health;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Image[] P2hearts;
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

        for(int i = 0; i < P2hearts.Length; i++) {
            if (i > player2Health - 1) {
                P2hearts[i].color = Color.black;
            }
        }
    }
    
}
