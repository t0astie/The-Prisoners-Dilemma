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

public struct GameData
{
    public List<Action> _player1Moves;
    public List<Action> _player2Moves;
}

public abstract class Moves : MonoBehaviour
{
    public abstract Action Play(GameData data);

    public Action GetAction(GameData data, Retaliation retaliation)
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

public class FirstTurn : Moves
{
    public Action _action;
    public override Action Play(GameData data)
    {
        throw new System.NotImplementedException();
    }
}

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
