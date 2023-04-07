using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class willl : MonoBehaviour
{
    
    public Text hitung;
    //public WillCounter wc;

    void Start()
    {
        hitung = GameObject.Find("WillCount").GetComponent<Text>();
    
        hitung.text = EndTrigger.goodWill.ToString();
    }
}
