using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Text timeText;
    public int time = 10;

    void Start()
    {
        StartCoroutine(RestartTheGame());
    }

    IEnumerator RestartTheGame()
    {
        for(int i = time; i > 0; i--)
        {
            timeText.text = "Restarting Game in ... " + i;
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
