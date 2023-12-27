using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public string _name;
    public abstract void Play();

    public Player(string name)
    {
        _name = name;
    }
}

public class Moves
{
    public enum MoveTypes
    {
        FirstTurn,
        OnTheXLastTurn,
        OnThePreviousXAmountOfTurns,
        IfAtAnyPoint
    }
}
