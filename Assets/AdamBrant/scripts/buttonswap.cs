using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonswap : MonoBehaviour {

    public GameObject Char;


    public void OnMouseEnter()
    {
        //Debug.Log("mouse is over button");
        Char.SetActive (true);
    }

    public void OnMouseExit()
    {
        //Debug.Log("Mouse has left the button");
        Char.SetActive(false);
    }
        
}
