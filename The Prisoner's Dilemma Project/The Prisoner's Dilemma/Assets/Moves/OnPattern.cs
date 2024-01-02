using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPattern : Moves      // IF PLAYER does a pattern of ACTIONs do RETALIATION
{
    public bool _player;    // TRUE is them, FALSE is you
    public List<Action> _action;    // Pattern to check
    public override Action Play(MatchData data)
    {
        List<Action> pActions = _player == false ? data._player1Moves : data._player2Moves;

        if (pActions.Count < _action.Count)
        {
            return Action.None;
        }

        for (int i = 0; i < _action.Count; i++)
        {
            if (pActions[pActions.Count - _action.Count + i] != _action[i])
            {
                return Action.None;
            }
        }

        return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>());
    }

    public override bool CheckMove()
    {
        if (_retaliation == Retaliation.None && _customRetaliation.Count == 0)
        {
            return false;
        }

        if (_action.Count == 0)
        {
            return false;
        }

        return true;
    }
}
