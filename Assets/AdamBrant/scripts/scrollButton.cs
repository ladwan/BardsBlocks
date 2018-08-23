using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollButton : MonoBehaviour
{
    Animator fade;
    Animator Scrollbottom;
    Animator Scrollbody;
    public GameObject fadeui;

    public GameObject scrollbody;
    public GameObject scrollbottom;

    private void Start()
    {
        fade = fadeui.GetComponent<Animator>();
        Scrollbottom = scrollbottom.GetComponent<Animator>();
        Scrollbody = scrollbody.GetComponent<Animator>();
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
        fade.SetBool("Activated", !fade.GetBool("Activated"));

        /* (fadeui.activeSelf & fade.GetBool("is open"))
        {
            fade.SetBool("fadeout", true);
            fade.SetBool("is open", false);
            deactivateUI();
            fadeui.SetActive(false);
        }
        else
        {
            fadeui.SetActive(true);
            fade.SetBool("is open", true);
            fade.SetBool("fadeout", false);
            fade.SetTrigger("animate fade");
        }*/
    }
    public void deactivateUI()
    {
        StartCoroutine(turnoff());
    }

    IEnumerator turnoff()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
