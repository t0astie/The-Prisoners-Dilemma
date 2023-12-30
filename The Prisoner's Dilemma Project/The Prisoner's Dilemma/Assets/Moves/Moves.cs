using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action
{
    None,
    Defect,
    Cooperate
}

public enum Retaliation
{
    Defect,
    Cooperate,
    SameAsPreviousTurn,
    OppisiteOfPreviousTurn
}

public abstract class Moves : MonoBehaviour
{
    public int _priority;
    public abstract Action Play(MatchData data);

    public Action GetAction(MatchData data, Retaliation retaliation)
    {
        if (retaliation == Retaliation.Defect)
        {
            return Action.Defect;
        }

        if (retaliation == Retaliation.Defect)
        {
            return Action.Cooperate;
        }

        if (retaliation == Retaliation.SameAsPreviousTurn)
        {
            return data._player1Moves[data._player1Moves.Count - 1];
        }

        if (retaliation == Retaliation.OppisiteOfPreviousTurn)
        {
            Action a = data._player1Moves[data._player1Moves.Count - 1];
            
            if (a == Action.Defect)
            {
                return Action.Cooperate;
            }

            return Action.Defect;
        }

        return Action.None;
    }
}
