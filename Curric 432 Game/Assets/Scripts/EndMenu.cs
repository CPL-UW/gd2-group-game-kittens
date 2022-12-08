using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text winText;
    public Image Player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(VariableController.PlayerWhoWon);
        if(VariableController.PlayerWhoWon == 1) {
            winText.text = "Player 1 Wins";
            Player.color = Color.white;
            Debug.Log("Player 1 Wins");
        }
        if(VariableController.PlayerWhoWon == 2) {
            winText.text = "Player 2 Wins";
            Player.color = Color.blue;
            Debug.Log("Player 2 Wins");
        }
    }

}
