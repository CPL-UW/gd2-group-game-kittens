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

    //Updates text
    void Update()
    {
        scoreText.text = gameManager.points.ToString();
    }
}
