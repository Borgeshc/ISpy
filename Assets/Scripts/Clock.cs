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
        minutes = 0;
        seconds = 0;
        source = GetComponent<AudioSource>();
        clock.text = hours + ":" + minutes + ":" + seconds;
    }

    void Update()
    {
        timer = Time.timeSinceLevelLoad;

        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);

        //if(seconds % 25 == 0 && seconds != sameTime && minutes != 1 && RaycastSelect.eyesOpened == true && !ObjectManager.chosingObject == false)
        //{
        //    sameTime = seconds;
        //    source.clip = whereCouldItBe;
        //    source.Play();
        //}

        if(minutes >= 1)
        {
            if(!soundPlaying && !ObjectManager.chosingObject)
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
