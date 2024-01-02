using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddPattern : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_Dropdown tMP_Dropdown;
    public void AddAction()
    {
        string action = tMP_Dropdown.GetComponentInChildren<TextMeshProUGUI>().text;
        GetComponentInParent<OnPattern>()._action.Add(IntToAction(tMP_Dropdown.value));
        text.text += "\n";
        text.text += action;
    }

    public Action IntToAction(int n)
    {
        if (n == 0)
        {
            return Action.Defect;
        }

        if (n == 1)
        {
            return Action.Cooperate;
        }
        
        return Action.None;
    }
}
