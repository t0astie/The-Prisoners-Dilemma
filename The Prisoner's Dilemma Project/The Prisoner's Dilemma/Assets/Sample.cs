using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sample : MonoBehaviour
{
    public int[] num = { 2, 1, 10, 7, 3};
    // Start is called before the first frame update
    void Start()
    {
        SortArray();
    }

    void SortArray()
    {
        Array.Sort(num);
    }
}
