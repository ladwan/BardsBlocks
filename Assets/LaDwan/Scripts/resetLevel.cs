using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resetLevel : MonoBehaviour {
    public Canvas AreYouSure;
    public int SceneToLoad;
    GameObject PauseREF,PauseButton;
	// Use this for initialization
	void Start ()
    {
        PauseREF = GameObject.FindGameObjectWithTag("PauseMenu");
        AreYouSure.enabled = false;
        SceneToLoad = SceneManager.GetActiveScene().buildIndex;
        PauseButton = GameObject.Find("PauseButton");

    }

    // Update is called once per frame


    public void StartReset()
    {
        PauseREF.GetComponent<PauseScript>().isPaused = true;
        PauseButton.SetActive(false);
        AreYouSure.enabled = true;
        Time.timeScale = 0;

    }
    public void Reset()
    {
        Time.timeScale = 1;
        PauseREF.GetComponent<PauseScript>().isPaused = false;
        PauseButton.SetActive(true);
        SceneManager.LoadScene(SceneToLoad);
    }

    public void CancelReset()
    {
        Time.timeScale = 1;
        PauseREF.GetComponent<PauseScript>().isPaused = false;
        PauseButton.SetActive(true);
        AreYouSure.enabled = false;
        
    }

}
