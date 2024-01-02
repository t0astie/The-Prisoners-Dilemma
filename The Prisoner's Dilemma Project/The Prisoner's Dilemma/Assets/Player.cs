using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string _name;
    public int _points;
    public Action _firstMove;
    public List<Moves> _moves;
    public List<Action> _currentRetaliation;
    int _action;

    private void Start() 
    {
        if (_currentRetaliation == null)
        {
            _currentRetaliation = new List<Action>();
        }
    }

    public Action FirstMove()
    {
        if (_firstMove == Action.None)
        {
            return UnityEngine.Random.Range(0f, 100f) < 50 ? Action.Defect : Action.Cooperate;
        }

        return _firstMove;
    }

    public Action Play(MatchData data)
    {
        int priority = 0;
        Action action = Action.None;

        if (_currentRetaliation.Count > 0)
        {
            _action++;
            Action customAction = _currentRetaliation[_action];
            if (_action < _currentRetaliation.Count - 1)
            {
                return customAction;
            }
            
            customAction = _currentRetaliation[_currentRetaliation.Count - 1];
            _currentRetaliation = new List<Action>();
            _action = 1;
            
            return customAction;
        }

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
