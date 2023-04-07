using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    
    public GameObject popupAntidepresan;

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            popup();
            other.gameObject.GetComponent<PlayerHealth>().Heal();
            Destroy(gameObject);
        }
    }


    void popup()
    {
        GameObject popup = Instantiate(popupAntidepresan, new Vector3(0,0,0), Quaternion.identity);
        Time.timeScale = 0;
    }

    public void jalanlagi()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
