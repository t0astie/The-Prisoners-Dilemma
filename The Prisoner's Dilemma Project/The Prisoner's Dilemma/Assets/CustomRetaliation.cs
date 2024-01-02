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
        text.text += "\n";
        text.text += action;
    }
}
