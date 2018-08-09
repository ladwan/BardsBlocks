using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFade : MonoBehaviour
{

    Animator Fade;

    private void Start()
    {
        Fade = GetComponent<Animator>();
    }


    public void OnMouseEnter()
    {
        Debug.Log("mouse over canvas, showing ui!");
        Fade.SetTrigger("pointer on icons");
        Fade.SetBool("is using", true);
    }

    public void OnMouseExit()
    {
        Debug.Log("mouse not on ui, fading away!");
        Fade.SetTrigger("pointer on icons");
        Fade.SetBool("is using", false);
    }
}