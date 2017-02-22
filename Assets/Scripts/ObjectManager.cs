using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> pickupables;
    public int RequiredObjects = 5;

    public GameObject requiredObject;

    void Start ()
    {
        requiredObject = pickupables[Random.Range(0, pickupables.Count)];
        requiredObject.GetComponent<AudioSource>().Play();
        print("I'm looking for my " + requiredObject.name);
    }

    public bool RemoveObject(GameObject collectible)
    {
        if (collectible == requiredObject)
        {
            print("Ha! I found it!");
            pickupables.Remove(collectible);
            RequiredObjects--;

            if (RequiredObjects <= 0)
            {
                SceneManager.LoadScene("WinScene");
            }
            requiredObject = pickupables[Random.Range(0, pickupables.Count)];
            requiredObject.GetComponent<AudioSource>().Play();
            print("Now I'm looking for my " + requiredObject.name);
            return true;
        }
        else
            return false;
    }
}

