using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRefScript : MonoBehaviour {

    public bool oneStar;
    public float oneStarThresh;
    public bool twoStar;
    public float twoStarThresh;
    public bool threeStar;
    public float threeStarThresh;

    public float stageScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (stageScore >= oneStarThresh)
        {
            oneStar = true;
        }
        if (stageScore >= twoStarThresh)
        {
            twoStar = true;
        }
        if (stageScore >= threeStarThresh)
        {
            threeStar = true;
        }

    }
}
