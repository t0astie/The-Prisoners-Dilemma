using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public struct GameData
{
    public List<MatchData> _matches;
}

[System.Serializable]
public struct MatchData
{
    public Player _player1;
    public Player _player2;
    public Player _winner;
    public int _player1Points;
    public int _player2Points;
    public List<Action> _player1Moves;
    public List<Action> _player2Moves;

    public MatchData(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _winner = null;
        _player1Points = 0;
        _player2Points = 0;
        _player1Moves = new List<Action>();
        _player2Moves = new List<Action>();
    }
}

public class PlayGame : MonoBehaviour
{
    int[,] _playerPoints = {{1,5}, {0, 3}};
    public int _rounds, _roundLengthVariance;
    public GameData gameData;
    public Player[] _players;

    private void Start() 
    {
        
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            gameData._matches = new List<MatchData>();
            RunGame();
        }
    }

    public void RunGame()
    {
        int n = 0;
        for (int i = 0; i < _players.Length; i++)
        {
            for (int ii = n; ii < _players.Length; ii++)
            {
                Debug.Log($"{_players[i].Name} is playing against {_players[ii].Name}");
               gameData._matches.Add(RunMatch(_players[i], _players[ii]));
            }

            n++;
        }
    }
    
    public MatchData RunMatch(Player player1, Player player2)
    {   
        int rounds = _rounds + UnityEngine.Random.Range(-_roundLengthVariance, _roundLengthVariance);
        MatchData data = new MatchData(player1, player2);

        data._player1Moves.Add(player1._firstMove);
        data._player2Moves.Add(player2._firstMove);

        GetPoints(player1._firstMove, player2._firstMove, data);

        for (int i = 0; i < rounds; i++)
        {
            Action player1Move = player1.Play(data);
            Action player2Move = player2.Play(data);

            data._player1Moves.Add(player1Move);
            data._player2Moves.Add(player2Move);

            GetPoints(player1Move, player2Move, data);
        }

        data._winner = data._player1Points > data._player2Points ? player1 : player2;
        player1._points += data._player1Points;
        player2._points += data._player2Points;

        return data;
    }

    public void GetPoints(Action action1, Action action2, MatchData data)
    {
        int player1Move = action1 == Action.Defect ? 0 : 1;
        int player2Move = action2 == Action.Defect ? 0 : 1;

        data._player1Points += _playerPoints[player1Move, player2Move];
        data._player2Points += _playerPoints[player2Move, player1Move];
    }
}
