using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPreviousTurn : Moves
{
    public Action _action;
    public Retaliation _retaliation;
    public override Action Play(GameData data)
    {
        if (data._player2Moves[data._player2Moves.Count - 1] == _action)
        {
            return GetAction(data, _retaliation);
        }

        return Action.None;
    }
}