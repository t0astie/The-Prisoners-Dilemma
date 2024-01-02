using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Action
{
    None,
    Defect,
    Cooperate
}

public enum Retaliation
{
    None,
    Defect,
    Cooperate,
    Random,
    SameAsPreviousTurn,
    OppisiteOfPreviousTurn,
    CustomRetaliation
}

public abstract class Moves : MonoBehaviour
{
    public int _priority;
    public Retaliation _retaliation;
    public List<Action> _customRetaliation;
    public abstract Action Play(MatchData data); // Takes the current match data and which player is playing
    public abstract bool CheckMove();
    public virtual void LoadData(Moves m)
    {
        _retaliation = m._retaliation;
        _customRetaliation = new List<Action>(m._customRetaliation); // Deep copy of the list
    }

    public Action GetAction(MatchData data, Retaliation retaliation, List<Action> customRetaliation, Player player)
    {
        if (customRetaliation.Count > 0)
        {
            player._currentRetaliation = customRetaliation;
            return customRetaliation[0];
        }

        if (retaliation == Retaliation.Defect)
        {
            return Action.Defect;
        }

        if (retaliation == Retaliation.Cooperate)
        {
            return Action.Cooperate;
        }

        if (retaliation == Retaliation.Random)
        {
            return UnityEngine.Random.Range(0f, 100f) < 50 ? Action.Defect : Action.Cooperate;
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

    public void ChangeRetaliation(int n)
    {
        _retaliation = IntToRetaliation(n);
    }

    public void ActionToCustomRetaliation(int n)
    {
        _customRetaliation.Add(IntToAction(n));
    }

    public Action IntToAction(int n)
    {
        if (n == 1)
        {
            return Action.Defect;
        }

        if (n == 2)
        {
            return Action.Cooperate;
        }
        
        return Action.None;
    }

    public Retaliation IntToRetaliation(int n)
    {
        if (n == 1)
        {
            return Retaliation.Defect;
        }

        if (n == 2)
        {
            return Retaliation.Cooperate;
        }

        if (n == 3)
        {
            return Retaliation.Random;
        }

        if (n == 4)
        {
            return Retaliation.SameAsPreviousTurn;
        }

        if (n == 5)
        {
            return Retaliation.OppisiteOfPreviousTurn;
        }

        if (n == 6)
        {
            return Retaliation.CustomRetaliation;
        }
        
        return Retaliation.None;
    }
}
