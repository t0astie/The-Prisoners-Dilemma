using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Players
{
    Player1,
    Player2
}

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
    SameAsPlayer2PreviousTurn,
    OppisiteAsPlayer2PreviousTurn
}

[System.Serializable]
public struct FirstTurn
{
    public Action _action;
}

[System.Serializable]
public struct OnTheXLastTurn
{
    public Players _player;
    public int _turn;
    public Action _action;
    public Retaliation _retaliation;
}

[System.Serializable]
public struct OnThePreviousXAmountOfTurns
{
    public Players player;
    public int turn;
    public Action action;
    public Retaliation _retaliation;
}

[System.Serializable]
public struct OnAnyGivenTurn
{
    [Range (0f, 100f)] public float chance;
    public Retaliation _retaliation;
}