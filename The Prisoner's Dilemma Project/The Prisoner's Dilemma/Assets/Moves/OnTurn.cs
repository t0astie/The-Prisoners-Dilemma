using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTurn : Moves
{
    public int _turn;
    public override Action Play(MatchData data)
    {
        if (_turn > data._player1Moves.Count + 1)
        {
            return Action.None;
        }

        if (data._player1Moves.Count + 1 == _turn)
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

        if (_turn < 0)
        {
            return false;
        }

        return true;
    }
}
