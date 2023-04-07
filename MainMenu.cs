using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("StoryAwal");
        EndTrigger.levelIndex = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //public void SceneRandom()
    //{
        //SceneManager.LoadScene(Random.Range(6,14));
    //}

    public void SceneRandom()
    {
        if(EndTrigger.goodWill >= 7)
        {
            SceneManager.LoadScene(Random.Range(9, 11));
        }
            if(EndTrigger.goodWill <= 3)
            {
                SceneManager.LoadScene(Random.Range(6, 8));
            }
                if(EndTrigger.goodWill > 3 && EndTrigger.goodWill < 7)
                {
                    SceneManager.LoadScene(Random.Range(12, 14));
                }

        EndTrigger.levelIndex++;
    } 

    public void NextLevelMenu()
    {
        SceneManager.LoadScene("NextLevel");
    }

    public void GuideMenu()
    {
        SceneManager.LoadScene("GuideMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void mainLagi()
    {
        SceneManager.LoadScene("Intro");
        //EndTrigger.levelIndex++;
    }

    public void game()
    {
        SceneManager.LoadScene("TopDownGame");
    }

    public void level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void gantiBulan()
    {
        if(EndTrigger.levelIndex == 1)
        {
            SceneManager.LoadScene("level1");
        }
            if(EndTrigger.levelIndex == 2)
            {
                SceneManager.LoadScene("level2");
            }
                if(EndTrigger.levelIndex == 3)
                {
                    SceneManager.LoadScene("level3");
                }
                    if(EndTrigger.levelIndex == 4)
                    {
                        SceneManager.LoadScene("level4");
                    }
                        if(EndTrigger.levelIndex == 5)
                        {
                            SceneManager.LoadScene("level5");
                        }
                            if(EndTrigger.levelIndex == 6 && EndTrigger.goodWill > 6)
                            {
                                SceneManager.LoadScene("GoodEnding");
                                FindObjectOfType<TImer>().currentTime = 60;
                            }

                            if(EndTrigger.levelIndex == 6 && EndTrigger.goodWill < 4)
                            {
                                SceneManager.LoadScene("BadEnding");
                                FindObjectOfType<TImer>().currentTime = 60;
                            }

                            if(EndTrigger.levelIndex == 6 && EndTrigger.goodWill > 3 && EndTrigger.goodWill < 7)
                            {
                                SceneManager.LoadScene("NeutralEnding");
                                FindObjectOfType<TImer>().currentTime = 60;
                            }
    }

    public void firstgame()
    {
        //SceneManager.LoadScene("FrstGameplay");
        SceneManager.LoadScene("MasukRSJ");
    }
    
    public void resett()
    {
        EndTrigger.goodWill = 5;
    }
}
