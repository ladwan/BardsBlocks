using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUse : MonoBehaviour {

    Animator power1anim;
    Animator power2anim;
    public GameObject power1;
    public GameObject power2;
    public GameObject powerIndicator;
    // Use this for initialization
    void Start () {
        power1anim = power1.GetComponent<Animator>();
        power2anim = power2.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void slideAnim()
    {
        if (powerIndicator != null)
        {
            power1anim.SetTrigger("animate slide");
            power2anim.SetTrigger("animate slide");
        }
        else
        {
            Debug.Log("ya fucked up");
        }
    }

    public void toggleActive1()
    {
        if (power1.activeSelf)
        {
            power1.SetActive(false);
        }
        else
        {
            power1.SetActive(true);
        }
    }
    public void toggleActive2()
    {
        if (power2.activeSelf)
        {
            power2.SetActive(false);
        }
        else
        {
            power2.SetActive(true);
        }
    }
}
