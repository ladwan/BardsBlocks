using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public bool isPaused;

    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//if (isPaused == true)
		//{
		//	if (Time.timeScale == 1)
		//	{
		//		Time.timeScale = 0;
		//	}
		//	else
		//	{
		//		Time.timeScale = 1;
		//	}

		//}

	}

	public void PauseGame(){
		
		isPaused = true;

        pauseMenu.SetActive(true);

        Time.timeScale = 0;

	}

	public void UnpauseGame(){
		isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
	}
}
