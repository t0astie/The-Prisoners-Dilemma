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
        int priority = 999;
        Action action = Action.None;

        foreach (Moves move in _moves)
        {
            if (move._priority < priority)
            {
                Action pAction = move.Play(data);
                if (pAction != Action.None)
                {
                    action = pAction;
                    priority = move._priority;
                }
            }
        }

        return action;
    }

    public string Name 
    {
        get { return _name; }
        set { _name = value; }
    }
}
