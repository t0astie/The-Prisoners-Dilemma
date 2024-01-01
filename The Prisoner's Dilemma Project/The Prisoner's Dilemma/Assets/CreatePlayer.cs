using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    PlayGame game;
    public GameObject _playerPrefab;
    private void Start() 
    {
        game = FindObjectOfType<PlayGame>();
    }

    void NewPlayer()
    {
        GameObject player = Instantiate(_playerPrefab);
        game.AddPlayer(player);
    }

    public void ChanceAction(Moves moves)
    {
        
    }
}
