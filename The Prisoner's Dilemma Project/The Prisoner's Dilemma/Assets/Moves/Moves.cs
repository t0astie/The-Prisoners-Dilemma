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
    CustomRetaliation,
    SameAsPreviousTurn,
    OppisiteOfPreviousTurn
}

public abstract class Moves : MonoBehaviour
{
    public int _priority;
    public Retaliation _retaliation;
    public List<Action> _customRetaliation;
    public abstract Action Play(MatchData data); // Takes the current match data and which player is playing
    public void SetPriority(int value)
    {
        string t = GetComponentInChildren<TMP_Dropdown>().options[value].text;
        Debug.Log(t);
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

    public Action TextToAction(string s)
    {
        if (s == "Defect")
        {
            return Action.Defect;
        }

        if (s == "Cooperate")
        {
            return Action.Cooperate;
        }
        
        return Action.None;
    }

    public Retaliation TextToRetaliation(string s)
    {
        if (s == "Defect")
        {
            return Retaliation.Defect;
        }

        if (s == "Cooperate")
        {
            return Retaliation.Cooperate;
        }

        if (s == "Random")
        {
            return Retaliation.Random;
        }

        if (s == "Same as previous turn")
        {
            return Retaliation.SameAsPreviousTurn;
        }

        if (s == "Oppisite of previous turn")
        {
            return Retaliation.OppisiteOfPreviousTurn;
        }
        
        return Retaliation.None;
    }
}
