using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public GameObject popupAmmo;

    // Update is called once per frame
    void Update()
    {
        
    }

 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            popupammo();
            other.gameObject.GetComponent<Shooting>().Reload();
            Destroy(gameObject);
        }
    }

    void popupammo()
    {
        GameObject popup = Instantiate(popupAmmo, new Vector3(0,0,0), Quaternion.identity);
        Time.timeScale = 0;
    }
}
