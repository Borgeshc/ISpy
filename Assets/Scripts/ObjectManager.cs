using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> pickupables;
    public int RequiredObjects = 5;

    public GameObject requiredObject;
    bool waiting;

    public AudioClip foundEverything;
    public AudioClip mom;

    AudioSource source;
    bool gameEnding;

    void Start ()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Mom());
    }

    public bool RemoveObject(GameObject collectible)
    {
        if (collectible == requiredObject)
        {
            pickupables.Remove(collectible);
            RequiredObjects--;

            if (RequiredObjects <= 0)
            {
                if(!gameEnding)
                {
                    gameEnding = true;
                    StartCoroutine(EndGame());
                }
            }
            requiredObject = pickupables[Random.Range(0, pickupables.Count)];
            if(!waiting && !gameEnding)
            {
                waiting = true;
                StartCoroutine(WaitTime());
            }
         //   print("Now I'm looking for my " + requiredObject.name);
            return true;
        }
        else
            return false;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
        requiredObject.GetComponent<AudioSource>().Play();
        waiting = false;
        
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.5f);
        source.clip = foundEverything;
        source.Play();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("WinScene");
    }

    IEnumerator Mom()
    {
        source.clip = mom;
        source.Play();
        yield return new WaitForSeconds(10f);

        requiredObject = pickupables[Random.Range(0, pickupables.Count)];
        requiredObject.GetComponent<AudioSource>().Play();
    }
}

