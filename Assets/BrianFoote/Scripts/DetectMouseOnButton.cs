using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectMouseOnButton : MonoBehaviour  {
	public GameObject playerRef;
	public bool buttonIsActive;

	public bool doubleJumpButton;
	public bool protectButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		playerRef = GameObject.FindGameObjectWithTag ("Player");

		if (Input.GetMouseButtonUp (0) && buttonIsActive == true && doubleJumpButton == true) {
			playerRef.GetComponent<BasicPlayerScript> ().ActivateDoubleJump ();
		}
		if (Input.GetMouseButtonUp (0) && buttonIsActive == true && protectButton == true) {
			Debug.Log ("Protect active");
			playerRef.GetComponent<BasicPlayerScript> ().ActivateProtect ();
		}
		
	}



	public void PointerHasEntered(){
        if (playerRef.GetComponent<BasicPlayerScript>().canDoubleJump == true && doubleJumpButton == true)
        {
            buttonIsActive = true;
        }

        if (playerRef.GetComponent<BasicPlayerScript>().canProtect == true && protectButton == true)
        {
            buttonIsActive = true;
        }
    }

	public void PointerHasExited(){
		Debug.Log ("Button is not active");
		buttonIsActive = false;
	}
}
