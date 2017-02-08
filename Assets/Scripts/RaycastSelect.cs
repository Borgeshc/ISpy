using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastSelect : MonoBehaviour
{
    RaycastHit hit;
    public GameObject reticleHolder;
    public GameObject backpack;
    Image reticleImage;
    bool isSelecting;
    ObjectManager objectManager;
    GameObject button;
    void Start()
    {
        objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();

        reticleImage = reticleHolder.GetComponent<Image>();
        reticleHolder.SetActive(false);
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 500))
        {
            if(hit.transform.tag == "Collectable")
            {
                if(!isSelecting)
                    StartCoroutine(Selecting(hit.transform.gameObject));

                reticleHolder.SetActive(true);
            }
            if (hit.transform.tag == "Static")
            {
                if (!isSelecting)
                    StartCoroutine(Selecting());

                reticleHolder.SetActive(true);
            }
            if(hit.transform.tag == "StartButton")
            {
                if (!isSelecting)
                    StartCoroutine(Selecting("Game"));

                reticleHolder.SetActive(true);
            }
        }
        else
        {
            ResetFill();
            reticleHolder.SetActive(false);
        }
    }

    IEnumerator Selecting(string scene)
    {

        isSelecting = true;
        while (reticleImage.fillAmount < 1)
        {
            reticleImage.fillAmount += .01f;
            yield return new WaitForSeconds(.01f);
        }
        isSelecting = false;
        SceneManager.LoadScene(scene);
    }
    IEnumerator Selecting(GameObject pickupable)
    {
        isSelecting = true;
        while(reticleImage.fillAmount < 1)
        {
            reticleImage.fillAmount += .01f;
            yield return new WaitForSeconds(.01f);
        }
        isSelecting = false;
        pickupable.transform.position= backpack.transform.position;
        objectManager.RemoveObject(pickupable);
    }

    IEnumerator Selecting()
    {
        isSelecting = true;
        while (reticleImage.fillAmount < 1)
        {
            reticleImage.fillAmount += .01f;
            yield return new WaitForSeconds(.01f);
        }
        isSelecting = false;
        //Play audio here
    }

    void ResetFill()
    {
        reticleImage.fillAmount = 0f;
    }
}
