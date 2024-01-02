using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTurn : Moves
{
    public int _turn = -1;
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

    public void ChangeTurn(string s)
    {
        if (s == "")
        {
            _turn = -1;
            return;
        }

        int n = int.Parse(s);
        _turn = n;
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

    public override void LoadData(Moves m)
    {
        base.LoadData(m);

        if (m is OnTurn onTurn)
        {
            _turn = onTurn._turn;
        }
    }
}
