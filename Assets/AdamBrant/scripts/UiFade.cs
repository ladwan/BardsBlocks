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
        Fade = GetComponent<Animator>();
    }


    public void toggleUI()
    {
        if(fadeui.activeSelf)
        {
            Debug.Log("fading away!");
            Fade.SetTrigger("animate fade");
            deactivateUI();
        }
        else
        {
            Debug.Log("showing ui!");
            Fade.SetTrigger("animate fade");
        }
        
    }

    public void deactivateUI()
    {
        StartCoroutine(turnoff());
    }

    IEnumerator turnoff()
    {
        yield return new WaitForSeconds(0.25f);
    }
}