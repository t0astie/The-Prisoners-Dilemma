using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _name;
    public List<Moves> playerMoves = new List<Moves>();

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
