using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenScript : MonoBehaviour {
    public int scencetoload;

	// Use this for initialization
	void Start () {
        StartCoroutine(Load());
	}
	
	// Update is called once per frame
	void Update () {


	}
    IEnumerator Load()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(scencetoload);

    }

}
