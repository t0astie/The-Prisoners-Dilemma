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
        GetComponentInParent<Moves>()._customRetaliation.Add(IntToAction(tMP_Dropdown.value));
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
