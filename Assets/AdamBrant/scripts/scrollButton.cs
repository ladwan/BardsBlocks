using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollButton : MonoBehaviour
{

    Animator Scrollbottom;
    Animator Scrollbody;
    public GameObject fadeui;

    public GameObject scrollbody;
    public GameObject scrollbottom;

    private void Start()
    {
        Scrollbottom = scrollbottom.GetComponent<Animator>();
        Scrollbody = scrollbody.GetComponent<Animator>();
        buttonanimate();
        GetComponent<UiFade>().toggleUI();
        fadeui.SetActive(false);
    }
    public void buttonanimate()
    {
        if (scrollbottom != null)
        {
            Scrollbottom.SetTrigger("button clicked");
            Scrollbody.SetTrigger("button clicked");
        }
        else
        {
            Debug.Log("ya fucked up");
        }
        
    }
    public void toggleActive()
    {
        if (fadeui.activeSelf)
        {
            fadeui.SetActive(false);
        }
        else
        {
            fadeui.SetActive(true);
        }
    }
}
