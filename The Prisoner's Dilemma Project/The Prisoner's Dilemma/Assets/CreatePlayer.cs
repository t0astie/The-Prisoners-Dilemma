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

    void NewPlayer()
    {
        currentPlayerObj = Instantiate(_playerPrefab);
        currentPlayer = currentPlayerObj.GetComponent<Player>();
    }

    public void AddMove(Moves m)
    {
        if (m._customRetaliation.Count == 0 && m._retaliation == Retaliation.None)
        {
            return;
        }
        
        Moves move = currentPlayerObj.AddComponent(m.GetType()) as Moves;
        currentPlayer._moves.Add(move);
    }
}
