using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPreviousTurn : Moves     // IF PLAYER on the previous turn did ACTION do RETALIATION
{
    public bool _player;    // TRUE is them, FALSE is you
    public Action _action;
    public override Action Play(MatchData data)
    {
        List<Action> pActions = _player == false ? data._player1Moves : data._player2Moves;
        if (pActions[pActions.Count - 1] == _action)
        {
            return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>());
        }

        return Action.None;
    }

    public override bool CheckMove()
    {
        if (_retaliation == Retaliation.None && _customRetaliation.Count == 0)
        {
            return false;
        }

        return true;
    }
}