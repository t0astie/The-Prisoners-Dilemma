using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPattern : Moves      // IF PLAYER does a pattern of ACTIONs do RETALIATION
{
    public bool _player;    // TRUE is them, FALSE is you
    public List<Action> _action;
    public Retaliation _retaliation;
    public override Action Play(MatchData data)
    {
        List<Action> player = _player == false ? data._player1Moves : data._player2Moves;

        if (player.Count < _action.Count)
        {
            return Action.None;
        }

        for (int i = 0; i < _action.Count; i++)
        {
            if (player[player.Count - _action.Count + i] != _action[i])
            {
                return Action.None;
            }
        }

        return GetAction(data, _retaliation);
    }
}
