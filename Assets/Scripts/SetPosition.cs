using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    Vector3 myPosition;
    void Start()
    {
        myPosition = transform.position;
    }

    void Update()
    {
        transform.position = myPosition;
    }
}
