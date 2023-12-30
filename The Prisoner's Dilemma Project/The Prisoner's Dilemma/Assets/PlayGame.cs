using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    int[,] _playerPoints = {{1,5}, {0, 3}};
    public int _rounds, _roundLengthVariance;

    public Player[] _players;

    private void Start() 
    {
        RunGame();
    }

    public void RunGame()
    {
        
    }
    public void RunMatch(Player player1, Player player2)
    {   
        int rounds = _rounds + UnityEngine.Random.Range(-_roundLengthVariance, _roundLengthVariance);
        GameData data = new GameData();

        data._player1Moves.Add(player1._firstMove);
        data._player2Moves.Add(player2._firstMove);

        for (int i = 0; i < rounds; i++)
        {
            Action player1Move = player1.Play(data);
            Action player2Move = player2.Play(data);

            data._player1Moves.Add(player1Move);
            data._player2Moves.Add(player2Move);

            GivePoints(player1, player2, player1Move, player2Move);
        }
    }

    public void GivePoints(Player player1, Player player2, Action action1, Action action2)
    {
        int player1Move = action1 == Action.Defect ? 0 : 1;
        int player2Move = action2 == Action.Defect ? 0 : 1;

        player1._points += _playerPoints[player1Move, player2Move];
        player2._points += _playerPoints[player2Move, player1Move];
    }
}
