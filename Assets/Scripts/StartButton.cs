using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void Scale()
    {
        transform.GetComponent<RectTransform>().localScale = new Vector3(.75f, .75f,.75f);
    }

    public void UnScale()
    {
        transform.GetComponent<RectTransform>().localScale = new Vector3(.5f, .5f, .5f);
    }
}
