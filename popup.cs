using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class popup : MonoBehaviour
{
   

   public GameObject popupp;
   bool UdahKena = false;

   void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.tag == "Player" && UdahKena == false)
       {
           Instantiate(popupp, new Vector3(0,0,0), Quaternion.identity);
           UdahKena = true;
           Time.timeScale = 0;
       }
   }
}
