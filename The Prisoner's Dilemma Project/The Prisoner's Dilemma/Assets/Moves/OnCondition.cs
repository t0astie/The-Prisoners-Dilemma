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
}
