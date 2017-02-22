using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public Animator anim;

    public void PlayAnim()
    {
        anim.SetBool("Opening", true);
    }
}
