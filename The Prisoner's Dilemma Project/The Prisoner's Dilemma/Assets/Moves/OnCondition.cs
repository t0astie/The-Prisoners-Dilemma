using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCondition : Moves    // IF at any point during the match PLAYER did ACTION do RETALIATION
{
    public bool _player;    // TRUE is them, FALSE is you
    public Action _action;
    public Retaliation _retaliation;
    public override Action Play(MatchData data)
    {
        List<Action> player = _player == false ? data._player1Moves : data._player2Moves;

        for (int i = 0; i < player.Count; i++)
        {
            if (player[i] == _action)
            {
                return GetAction(data, _retaliation);
            }
        }

        return Action.None;
    }
}
