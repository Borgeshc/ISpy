using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyes : MonoBehaviour
{
    public GameObject topEye;
    public GameObject bottomEye;

    public float topEyeOpen;
    public float topEyeClose;

    public float bottomEyeOpen;
    public float bottomEyeClose;

    public bool isSeen;

    void Start()
    {
        IsSeen();
    }
    void IsSeen()
    {
        topEye.GetComponent<RectTransform>().position = new Vector3(transform.position.x, Mathf.Lerp(topEyeClose, topEyeOpen, .005f * Time.deltaTime), transform.position.z);
        bottomEye.GetComponent<RectTransform>().position = new Vector3(transform.position.x, Mathf.Lerp(bottomEyeClose, bottomEyeOpen, .005f * Time.deltaTime), transform.position.z);
    }

    void IsNotSeen()
    {
        topEye.GetComponent<RectTransform>().position = new Vector3(transform.position.x, Mathf.Lerp(topEyeOpen, topEyeClose, 5 * Time.deltaTime), transform.position.z);
        bottomEye.GetComponent<RectTransform>().position = new Vector3(transform.position.x, Mathf.Lerp(bottomEyeOpen, bottomEyeClose, 5 * Time.deltaTime), transform.position.z);
    }
}
