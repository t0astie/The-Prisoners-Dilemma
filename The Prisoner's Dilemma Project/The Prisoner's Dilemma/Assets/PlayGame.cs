using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    int[,] playerPoints = {{1,5}, {0, 3}};
    int player1Score;
    int player2Score;

    bool playerTurn; // Player 1 is 0, player 2 is 1

    int player1Move; // 0 is defect, 1 is cooperate
    int player2Move;

    int turns;

    public void Play(string s)
    {
        if (s == "Defect")
        {
            if (playerTurn)
            {
                playerTurn = !playerTurn;
                turns++;
                player2Move = 0;
                return;
            }

            playerTurn = !playerTurn;
            turns++;
            player1Move = 0;
            return;
        }

        if (s == "Cooperate")
        {
            if (playerTurn)
            {
                playerTurn = !playerTurn;
                turns++;
                player2Move = 1;
                return;
            }

            playerTurn = !playerTurn;
            turns++;
            player1Move = 1;
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

            if (player1Move == 0)
            {
                player1 = "defected";
            }

            if (player2Move == 0)
            {
                player2 = "defected";
            }

            player1Score += playerPoints[player1Move, player2Move];
            player2Score += playerPoints[player2Move, player1Move];

            Debug.Log($"Player 1 has {player1} ({playerPoints[player1Move, player2Move]}), player 2 has {player2} ({playerPoints[player2Move, player1Move]})");
            Debug.Log($"Player 1 score is: {player1Score}, player 2 score is: {player2Score}");
        }
    }
}
