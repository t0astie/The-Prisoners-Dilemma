using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewCondition : MonoBehaviour
{
    public TMP_Dropdown _playerMoves1;
    public TMP_Dropdown _playerMoves2;
    public TMP_Dropdown _action1;
    public TMP_Dropdown _action2;
    public TMP_Dropdown _checks;

    public void AddCondition()
    {
        GetComponent<NumberOfMovesCondition>().AddCondition(StringToMoveType(_playerMoves1.options[_playerMoves1.value].text), StringToMoveType(_playerMoves2.options[_playerMoves2.value].text), 
            StringToAction(_action1.options[_action1.value].text), StringToAction(_action2.options[_action2.value].text), 
            StringToChecks(_checks.options[_checks.value].text));
    }

    MoveType StringToMoveType(string s)
    {   
        if (s == "Player 1 moves")
        {
            return MoveType.Player1Moves;
        }

        return MoveType.Player2Moves;
    }

    Action StringToAction(string s)
    {   
        if (s == "Defect")
        {
            return Action.Defect;
        }

        return Action.Cooperate;
    }

    Checks StringToChecks(string s)
    {   
        if (s == "Greater than")
        {
            return Checks.GreaterThan;
        }

        if (s == "Less than")
        {
            return Checks.LessThan;
        }

        return Checks.EqualTo;
    }
}
