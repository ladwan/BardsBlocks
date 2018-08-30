using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataPersistScript : MonoBehaviour {

	public GameObject playerRef;

    public int testInt;
    public float scoreSave;

	public float doubleJumpCountSave;
	public float protectCountSave;


	// Use this for initialization
	void Start () {
		testInt = PlayerPrefs.GetInt("Test Int");
		scoreSave = PlayerPrefs.GetFloat("Score Save");

		doubleJumpCountSave = PlayerPrefs.GetFloat ("Double Jump Count");
		protectCountSave = PlayerPrefs.GetFloat ("Protect Count");

		playerRef = GameObject.FindGameObjectWithTag ("Player");

		playerRef.GetComponent<BasicPlayerScript> ().doubleJumpUseCount = doubleJumpCountSave;
		playerRef.GetComponent<BasicPlayerScript> ().protectUseCount = protectCountSave;

        

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("f")) {
            scoreSave += playerRef.GetComponent<BasicPlayerScript>().playerScore;

            PlayerPrefs.SetFloat("Score Save", scoreSave);


            doubleJumpCountSave = playerRef.GetComponent<BasicPlayerScript>().doubleJumpUseCount;

            protectCountSave = playerRef.GetComponent<BasicPlayerScript>().protectUseCount;


            PlayerPrefs.SetFloat("Double Jump Count", doubleJumpCountSave);
            PlayerPrefs.SetFloat("Protect Count", protectCountSave);

            Debug.Log("Double Jump Count");
            Debug.Log(doubleJumpCountSave);
            Debug.Log("Protect Count");
            Debug.Log(protectCountSave);

            LoadScene ("TestScene1");
		}
		if (Input.GetKeyDown ("k")) {
			PlayerPrefs.DeleteKey ("Score Save");
			PlayerPrefs.DeleteKey ("Double Jump Count");
			PlayerPrefs.DeleteKey ("Protect Count");
//			PlayerPrefs.DeleteKey ("Score Save");

		}

	}

    void OnDestroy()
    {
		
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        scoreSave += playerRef.GetComponent<BasicPlayerScript>().playerScore;

        PlayerPrefs.SetFloat("Score Save", scoreSave);


        doubleJumpCountSave = playerRef.GetComponent<BasicPlayerScript>().doubleJumpUseCount;

        protectCountSave = playerRef.GetComponent<BasicPlayerScript>().protectUseCount;


        PlayerPrefs.SetFloat("Double Jump Count", doubleJumpCountSave);
        PlayerPrefs.SetFloat("Protect Count", protectCountSave);

        Debug.Log("Double Jump Count");
        Debug.Log(doubleJumpCountSave);
        Debug.Log("Protect Count");
        Debug.Log(protectCountSave);

        //LoadScene("TestScene1");
    }
}
