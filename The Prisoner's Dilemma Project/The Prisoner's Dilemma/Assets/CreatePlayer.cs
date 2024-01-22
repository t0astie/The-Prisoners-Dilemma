using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    PlayGame game;
    public GameObject _playerPrefab;
    public GameObject currentPlayerObj;
    public Player currentPlayer;
    private void Start() 
    {
        game = GetComponentInParent<PlayGame>();
    }

    public void NewPlayer()
    {
        currentPlayerObj = Instantiate(_playerPrefab);
        currentPlayer = currentPlayerObj.GetComponent<Player>();
    }

    public void AddPlayer()
    {
        game._players.Add(currentPlayer);
    }

    public void AddMove(Moves m)
    {
        if (!m.CheckMove())
        {
            return;
        }

        // Create a new instance of the Moves class and copy data
        Moves move = currentPlayerObj.AddComponent(m.GetType()) as Moves;
        move.LoadData(m);

        currentPlayer._moves.Add(move);
    }
}
