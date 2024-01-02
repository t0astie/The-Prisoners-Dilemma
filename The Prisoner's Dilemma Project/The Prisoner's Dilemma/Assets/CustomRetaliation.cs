using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomRetaliation : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_Dropdown tMP_Dropdown;
    public void AddAction()
    {
        string action = tMP_Dropdown.GetComponentInChildren<TextMeshProUGUI>().text;
        GetComponentInParent<Moves>()._customRetaliation.Add(TextToAction(action));
        text.text += "\n";
        text.text += action;
    }

    Action TextToAction(string s)
    {
        if (s == "Defect")
        {
            return Action.Defect;
        }

        if (s == "Cooperate")
        {
            return Action.Cooperate;
        }
        
        return Action.None;
    }
}
