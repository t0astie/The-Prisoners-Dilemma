using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string _name;
    public int _points;
    public Action _firstMove;
    public Moves[] _moves;

    private void Start() 
    {
        _moves = gameObject.GetComponents<Moves>();
    }

    public Action Play(MatchData data)
    {
        int priority = 0;
        Action action = Action.None;
        foreach (Moves move in _moves)
        {
            if (move._priority > priority)
            {
                Action pAction = move.Play(BigBrother(data));
                
                if (pAction != Action.None)
                {
                    action = pAction;
                    priority = move._priority;
                }
            }
        }

        return action;
    }

    public MatchData BigBrother(MatchData d)  // Always uses match data where this player is known as 'player1'. Method known as the big brother function
    {
        MatchData mData = new MatchData();

        if (d._player1 == this)
        {
            return d;
        }

        mData._player1 = d._player2;
        mData._player2 = d._player1;
        mData._player1Moves = d._player2Moves;
        mData._player2Moves = d._player1Moves;
        mData._player1Points = d._player2Points;
        mData._player2Points = d._player1Points;

        return mData;
    }

    public string Name 
    {
        get { return _name; }
        set { _name = value; }
    }
}
