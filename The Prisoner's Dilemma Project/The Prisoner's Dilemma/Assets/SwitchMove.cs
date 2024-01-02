using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMove : MonoBehaviour
{
    public GameObject[] _moves;
    GameObject _onMove;

    public void Switch(int n)
    {
        if (_onMove)
        {
            _onMove.SetActive(false);
        }

        _moves[n].SetActive(true);
        _onMove = _moves[n];
    }
}
