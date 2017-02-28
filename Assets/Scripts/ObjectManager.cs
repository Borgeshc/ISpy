using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public static bool chosingObject;
    public List<GameObject> pickupables;
    public int RequiredObjects = 5;

    public GameObject requiredObject;
    bool waiting;

    public AudioClip foundEverything;
    public AudioClip mom;
    public AudioClip whereCouldItBe;

    AudioSource source;
    bool gameEnding;
    Coroutine whereIsIt;

    void Start ()
    {
        chosingObject = false;
        source = GetComponent<AudioSource>();
        StartCoroutine(Mom());
    }

    public bool RemoveObject(GameObject collectible)
    {
        if (collectible == requiredObject)
        {
            pickupables.Remove(collectible);
            RequiredObjects--;

            if (whereIsIt != null && !source.isPlaying)
                StopCoroutine(whereIsIt);

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
                whereIsIt = StartCoroutine(StillLooking());
            }
         //   print("Now I'm looking for my " + requiredObject.name);
            return true;
        }
        else
            return false;
    }

    IEnumerator WaitTime()
    {
        chosingObject = true;
        yield return new WaitForSeconds(2);
        requiredObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        waiting = false;
        chosingObject = false;
        
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

    IEnumerator StillLooking()
    {
        yield return new WaitForSeconds(8);
        source.clip = whereCouldItBe;
        source.Play();
    }
}

