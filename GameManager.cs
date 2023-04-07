using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    bool gameFinished = false;


    public void GoodEnding()
    {
        if(EndTrigger.goodWill == 10)
        {
            gameFinished = true;
            SceneManager.LoadScene(16);
            EndTrigger.goodWill = 5;
            //TImer.currentTime = 60;
            FindObjectOfType<TImer>().currentTime = 60;
        }
    }

    public void BadEnding()
    {
        if(EndTrigger.goodWill == 0)
        {
            gameFinished = true;
            SceneManager.LoadScene(15);
            EndTrigger.goodWill = 5;
            //TImer.currentTime = 60;
            FindObjectOfType<TImer>().currentTime = 60;
        }
    }

    public void LevelComplete()
    {
        if(gameFinished == false)
        {
            gameFinished = true;
            Debug.Log("Menang ygy");
            Invoke("Menang", 1f);
        }
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            EndTrigger.goodWill--;
            Debug.Log("Darah Habis");
            Invoke("Kalah", 1f); // restart condition 
            //balik ke MENU
        }
       
    }

    void Kalah()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

    void Menang()
    {
        SceneManager.LoadScene("NextLevel");
    }
}
