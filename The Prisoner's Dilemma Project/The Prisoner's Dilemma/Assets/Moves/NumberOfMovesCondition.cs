using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NumberOfMovesCondition : Moves
{
    [System.Serializable]
    public struct Condition
    {
        public PlayerAction _playerAction;
        public Checks _check;
        public PlayerAction _checkAction;
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
    }

    [System.Serializable]
    public enum MoveType
    {
        Player1Moves,
        Player2Moves
    }
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
}
