using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    
    int player1Score;
    int player2Score;

    bool playerTurn; // Player 1 is 0, player 2 is 1

    bool player1Move; // 0 is defect, 1 is cooperate
    bool player2Move;

    int turns;

    public void Play(string s)
    {
        if (s == "Defect")
        {
            if (playerTurn)
            {
                playerTurn = !playerTurn;
                turns++;
                player2Move = false;
                return;
            }

            playerTurn = !playerTurn;
            turns++;
            player1Move = false;
            return;
        }

        if (s == "Cooperate")
        {
            if (playerTurn)
            {
                playerTurn = !playerTurn;
                turns++;
                player2Move = true;
                return;
            }

            playerTurn = !playerTurn;
            turns++;
            player1Move = true;
            return;
        }

        Debug.LogWarning("Invalid User entry. Please try again");
    }

    private void Update() 
    {
        if (turns == 2)
        {
            turns = 0;
            string player1 = "cooperated";
            string player2 = "cooperated";

            if (player1Move == false)
            {
                player1 = "defected";
            }

            if (player2Move == false)
            {
                player2 = "defected";
            }

            Debug.Log($"Player 1 has {player1}, player 2 has {player2}");
        }
    }
}
