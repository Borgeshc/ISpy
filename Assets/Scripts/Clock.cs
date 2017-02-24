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

    public AudioClip idBetterHurryUp;
    public AudioClip whereCouldItBe;

    AudioSource source;

    bool soundPlaying;
    float sameTime;

    void Start()
    {
        source = GetComponent<AudioSource>();
        clock.text = hours + ":" + minutes + ":" + seconds;
    }

    void Update()
    {
        timer = Time.time;

        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);

        if(seconds % 15 == 0 && seconds != sameTime && minutes != 1)
        {
            sameTime = seconds;
            source.clip = whereCouldItBe;
            source.Play();
        }

        print(seconds);
        if(minutes == 1)
        {
            if(!soundPlaying)
            {
                soundPlaying = true;
                source.clip = idBetterHurryUp;
                source.Play();
            }
        }

        if(minutes >= 2)
        {
            hours = 5;
            minutes = 0;
            SceneManager.LoadScene("LoseScene");
        }
        clock.text = string.Format("{0:D2}:{1:D2}:{2:D2}", 4 + hours, 58 + minutes, seconds);
    }
}
