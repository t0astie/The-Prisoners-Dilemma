using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public string _name;

    [Header("First Turn")]
    public FirstTurn firstTurn;
    
    [Header("On The X Last Turn")]
    public OnTheXLastTurn onTheXLastTurn;

    [Header("On The Previous X Amount Of Turns")]
    public OnThePreviousXAmountOfTurns onThePreviousXAmountOfTurns;

    [Header("On Any Given Turn")]
    public OnAnyGivenTurn onAnyGivenTurn;

    private void Start() 
    {

    }

    public void FirstMove()
    {

    }

    public void Play()
    {

    }

    public Player(string name)
    {
        _name = name;
    }
}
