using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TImer : MonoBehaviour
{
    bool timerActive = true;
    public float currentTime;
    public static int startSecond = 60;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true && currentTime > 0)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                EndTrigger.goodWill++;
                FindObjectOfType<GameManager>().LevelComplete();
                timerActive = false;
            }

            if(EndTrigger.goodWill >= 10)
            {
                FindObjectOfType<GameManager>().GoodEnding();
            }

            if(EndTrigger.goodWill <= 0)
            {
                FindObjectOfType<GameManager>().BadEnding();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

}
