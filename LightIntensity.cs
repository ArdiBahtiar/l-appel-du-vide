using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
 
    public Light lighting;
    public PlayerHealth hp;
    private float hpsekarang;

    void Start() 
    {
        lighting = GetComponent<Light>(); 
        hp = GetComponent<PlayerHealth>();
        hpsekarang = hp.currentHealth;

        lighting.intensity = (float)(hpsekarang * 0.01);
         //lighting.intensity = hp.currentHealth * 0.001;
    }   
}
