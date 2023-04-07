using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BulletCounter : MonoBehaviour
{

    public int bullet;
    public Text bulletAmount;

    void Start()
    {
        //GetComponent<Shooting>();
        bullet = FindObjectOfType<Shooting>().currentAmmo;    //GetComponent<Shooting>().currentAmmo;
    }

    void Update() 
    {
        bulletAmount.text = bullet.ToString();
    }
}
