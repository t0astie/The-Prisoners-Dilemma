using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _name;
    public int _points;
    public Dictionary<Moves, int> _moves = new Dictionary<Moves, int>();

    private void Start() 
    {
        foreach (Moves move in GetComponents<Moves>())
        {
            _moves.Add(move, 0);
        }
    }

    public Player(string name)
    {
        _name = name;
    }
}
