using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomRetaliation : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_Dropdown tMP_Dropdown;
    public GameObject[] objects;
    private void Update() 
    {
        if (GetComponentInParent<Moves>()._retaliation == Retaliation.CustomRetaliation)
        {
            foreach (GameObject obj in objects)
            {
                obj.gameObject.SetActive(true);
            }
        } 
        else 
        {
            text.text = "";
            GetComponentInParent<Moves>()._customRetaliation.Clear();
            foreach (GameObject obj in objects)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
    public void AddAction()
    {
        Debug.Log("add");
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
