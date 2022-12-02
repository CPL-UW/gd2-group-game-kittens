using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(VariableController.PlayerWhoWon);
        if(VariableController.PlayerWhoWon == 1) {
            Debug.Log("Player 1 Wins");
        }
        if(VariableController.PlayerWhoWon == 2) {
            Debug.Log("Player 2 Wins");
        }
    }

}
