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
        scencetoload = SceneREF.CurrentScene;

       
	}
    IEnumerator Load()
    {
        scencetoload = SceneREF.CurrentScene;
        if (scencetoload == 2)
        {
            scencetoload = 6;
        }
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(scencetoload);

    }

}
