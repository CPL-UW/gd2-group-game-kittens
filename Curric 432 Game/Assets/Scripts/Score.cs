using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Script for Score UI
*/
public class Score : MonoBehaviour
{
    public Text scoreText; //Text object with text
    public ItemCollect items;
    public int carrots;
    public GameManager gameManager;
    public bool isPlayer2;

    void Start() {
         
    }

    //Updates text
    void Update()
    {
        if(!isPlayer2) {
            scoreText.text = gameManager.points.ToString();
        } else {
            scoreText.text = gameManager.points2.ToString();
        }
    }
}
