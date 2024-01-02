using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public struct Condition
{
    public PlayerAction _playerAction;
    public Checks _check;
    public PlayerAction _checkAction;

    public Condition(MoveType move1, MoveType move2, Action action1, Action action2, Checks checks)
    {
        _playerAction = new PlayerAction(move1, action1);
        _check = checks;
        _checkAction = new PlayerAction(move2, action2);
    }
}

[System.Serializable]
public enum Checks
{
    GreaterThan,
    LessThan,
    EqualTo
}
[System.Serializable]
public struct PlayerAction
{
    public MoveType _moveType;
    public Action _action;
    public PlayerAction(MoveType moveType, Action action)
    {
        _moveType = moveType;
        _action = action;
    }
}

[System.Serializable]
public enum MoveType
{
    Player1Moves,
    Player2Moves
}

public class NumberOfMovesCondition : Moves
{
    
    public List<Condition> _conditions;
    public override Action Play(MatchData data)
    {
        foreach (Condition c in _conditions)
        {
            if (CheckCondition(c, data) == false)
            {
                return Action.None;
            }
        }

        return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>());
    }

    bool CheckCondition(Condition _condition, MatchData data)
    {
        List<Action> p1Moves = _condition._playerAction._moveType == MoveType.Player1Moves ? data._player1Moves : data._player2Moves;
        List<Action> p2Moves = _condition._checkAction._moveType == MoveType.Player1Moves ? data._player1Moves : data._player2Moves;

        if (_condition._check == Checks.GreaterThan)
        {
            if (GetMoves(_condition._playerAction._action, p1Moves) <= GetMoves(_condition._checkAction._action, p2Moves))
            {
                return false;
            }
        }

        if (_condition._check == Checks.LessThan)
        {
            if (GetMoves(_condition._playerAction._action, p1Moves) >= GetMoves(_condition._checkAction._action, p2Moves))
            {
                return false;
            }
        }

        if (_condition._check == Checks.EqualTo)
        {
            if (GetMoves(_condition._playerAction._action, p1Moves) != GetMoves(_condition._checkAction._action, p2Moves))
            {
                return false;
            }
        }

        return true;
    }

    public void AddCondition(MoveType move1, MoveType move2, Action action1, Action action2, Checks checks)
    {
        Condition c = new Condition(move1, move2, action1, action2, checks);
        _conditions.Add(c);
    }

    int GetMoves(Action actionToCheck, List<Action> actions)
    {
        int n = 0;
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i] == actionToCheck)
            {
                n++;
            }
        }

        return n;
    }

    public override bool CheckMove()
    {
        if (_retaliation == Retaliation.None && _customRetaliation.Count == 0)
        {
            return false;
        }

        if (_conditions.Count == 0)
        {
            return false;
        }

        return true;
    }

    public override void LoadData(Moves m)
    {
        base.LoadData(m);

        if (m is NumberOfMovesCondition numberOfMovesCondition)
        {
            _conditions = new List<Condition>(numberOfMovesCondition._conditions);
        }
    }
}
