using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    float timer = Time.time;
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
        hours = (int)timer % 24;
        hours = (int)timer / 24;
        ///this doesnt work yet!!
        ///
        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", 4 + hours, 55 + minutes, seconds);
    }
}
