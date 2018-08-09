using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRefScript : MonoBehaviour {

    public bool oneStar;
    public float oneStarThresh;
    public GameObject star1;
    public bool twoStar;
    public float twoStarThresh;
    public GameObject star2;
    public bool threeStar;
    public float threeStarThresh;
    public GameObject star3;

    public float stageScore;

	public GameObject playerRef;

	// Use this for initialization
	void Start () {

		playerRef = GameObject.FindGameObjectWithTag ("Player");
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		stageScore = playerRef.GetComponent<BasicPlayerScript> ().playerScore;

        if (stageScore >= oneStarThresh)
        {
            oneStar = true;
            star1.SetActive(true);
        }
        if (stageScore >= twoStarThresh)
        {
            twoStar = true;
            star2.SetActive(true);
        }
        if (stageScore >= threeStarThresh)
        {
            threeStar = true;
            star3.SetActive(true);
        }

    }
}
