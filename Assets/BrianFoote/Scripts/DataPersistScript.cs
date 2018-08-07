using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataPersistScript : MonoBehaviour {

    public int testInt = 2;
    public float testFloat = 4;

	// Use this for initialization
	void Start () {

        testInt = PlayerPrefs.GetInt("Test Int", 0);
        testFloat = PlayerPrefs.GetFloat("Test Float", 3);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        PlayerPrefs.SetInt("Test Int", testInt);
        PlayerPrefs.SetFloat("Test Float", testFloat);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
