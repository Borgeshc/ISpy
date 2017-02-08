using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> pickupables;
    private int objectCount;

    void Start () {
        objectCount = pickupables.Count;
    }

    public void RemoveObject(GameObject collectible)
    {
        pickupables.Remove(collectible);
        objectCount--;
        if (objectCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

