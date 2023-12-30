using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _name;
    public int _points;
    public Action _firstMove;
    public Moves[] _moves;

    private void Start() 
    {
        _moves = gameObject.GetComponents<Moves>();
    }

    public Action Play(MatchData data)
    {
        int priority = 999;
        Action action = Action.None;

        foreach (Moves move in _moves)
        {
            if (move._priority < priority)
            {
                action = move.Play(data);
            }
        }

        return action;
    }

    public Player(string name)
    {
        _name = name;
    }
}
