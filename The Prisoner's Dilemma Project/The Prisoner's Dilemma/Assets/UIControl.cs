using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject movesUI;
    public GameObject newPlayerButton;
    public GameObject addPlayerButton;
    public PlayGame pg;
    private void Start() {
        movesUI.SetActive(false);
        newPlayerButton.SetActive(true);
        addPlayerButton.SetActive(false);
    }
    public void NewPlayer() {

        movesUI.SetActive(true);
        newPlayerButton.SetActive(false);
        addPlayerButton.SetActive(true);
    }

    public void AddPlayer()
    {
        movesUI.SetActive(false);
        newPlayerButton.SetActive(true);
        addPlayerButton.SetActive(false);
    }
}
