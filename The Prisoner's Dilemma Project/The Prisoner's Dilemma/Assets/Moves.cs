using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moves : MonoBehaviour
{
    public enum Players
    {
        Player1,
        Player2
    }

    public enum Action
    {
        Defect,
        Cooperate
    }
    
    public abstract void ExcecuteMove();
}

public class FirstTurn : Moves
{
    public Action move;

    public override void ExcecuteMove()
    {
        throw new System.NotImplementedException();
    }
}

public class OnTheXLastTurn : Moves
{
    public Players player;
    public int turn;
    public Moves move;

    public override void ExcecuteMove()
    {
        throw new System.NotImplementedException();
    }
}

public class OnThePreviousXAmountOfTurns : Moves    // If on the X amount of previous turns player did move
{
    public Players player;
    public int turn;
    public Moves move;

    public override void ExcecuteMove()
    {
        throw new System.NotImplementedException();
    }
}
