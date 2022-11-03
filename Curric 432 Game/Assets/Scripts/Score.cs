using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Script for Score UI
*/
public class Score : MonoBehaviour
{
    //public PlayerMovement player;
    //public Carrot points
    public Text scoreText; //Text object with text
    public ItemCollect items;
    public int carrots;
    public GameManager gameManager;
    void Start()
    {
        
    }

    //Updates text
    void Update()
    {
        //scoreText.text = items.playerCarrots.ToString();
        //scoreText.text = gameManager.points.ToString();
    }
}
