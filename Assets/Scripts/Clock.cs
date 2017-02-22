using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    float timer;
    public Text clock;
    int hours;
    int minutes;
    int seconds;


    void Start()
    {
        clock.text = hours + ":" + minutes + ":" + seconds;
    }

    void Update()
    {
        timer = Time.time;

        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
        if(minutes >= 1)
        {
            hours = 5;
            minutes = 0;
            SceneManager.LoadScene("LoseScene");
        }
        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", 4 + hours, 55 + minutes, seconds);
    }
}
