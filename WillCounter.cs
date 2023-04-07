using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WillCounter : MonoBehaviour
{
    
    public Text will;
    public static int counter = 5;

    void Start()
    {
        will = GameObject.Find("Will").GetComponent<Text>();
        will.text = counter.ToString();
    }
}
