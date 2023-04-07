using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    public GameObject popupp;
    public static int goodWill = 5;
    public static int levelIndex = 1;
    


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            popups();
            FindObjectOfType<GameManager>().LevelComplete();
            goodWill++;
        }    
    }
    

    void popups()
    {
        Instantiate(popupp, new Vector3(0,0,0), Quaternion.identity);
        Time.timeScale = 0;
    }
}
