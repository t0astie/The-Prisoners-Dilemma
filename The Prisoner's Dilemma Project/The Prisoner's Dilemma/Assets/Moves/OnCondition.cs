using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCondition : Moves    // IF at any point during the match PLAYER did ACTION do RETALIATION
{
    public bool _player;    // TRUE is them, FALSE is you
    public Action _action;
    public override Action Play(MatchData data)
    {
        List<Action> pActions = _player == false ? data._player1Moves : data._player2Moves;

        for (int i = 0; i < pActions.Count; i++)
        {
            if (pActions[i] == _action)
            {
                return GetAction(data, _retaliation, _customRetaliation, GetComponent<Player>());
            }
        }

        return Action.None;
    }

    public void ChangePlayer(bool b)
    {
        _player = b;
    }

    public void ChangeAction(int n)
    {
        _action = IntToAction(n);
    }

    public override bool CheckMove()
    {
        if (_retaliation == Retaliation.None && _customRetaliation.Count == 0)
        {
            return false;
        }

        if (_action == Action.None)
        {
            return false;
        }

        return true;
    }

    public override void LoadData(Moves m)
    {
        base.LoadData(m);

        if (m is OnCondition onCondition)
        {
            _player = onCondition._player;
            _action = onCondition._action;
        }
    }
}
