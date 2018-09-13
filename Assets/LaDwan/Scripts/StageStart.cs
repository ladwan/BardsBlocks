using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour {

    public GameObject ScrollREF;

	// Use this for initialization
	void Start () {
        ScrollREF.GetComponent<scrollButton>().buttonanimate();
        ScrollREF.GetComponent<scrollButton>().toggleActive();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
