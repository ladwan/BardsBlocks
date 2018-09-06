using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFade : MonoBehaviour
{
    public GameObject fadeui;
    Animator Fade;

    private void Start()
    {
        //Fade = GetComponent<Animator>();
    }


    public void toggleUI()
    {
        if(fadeui.activeSelf)
        {
            Debug.Log("fading away!");
            Fade.SetTrigger("pointer on icons");
            Fade.SetBool("is using", false);
        }
        else
        {
            Debug.Log("showing ui!");
            Fade.SetTrigger("pointer on icons");
            Fade.SetBool("is using", true);
        }
        
    }
}