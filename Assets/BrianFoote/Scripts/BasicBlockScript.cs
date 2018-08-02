using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlockScript : MonoBehaviour {

	public Transform northBlock;
    public Transform farNorthBlock;
	public Transform eastBlock;
    public Transform farEastBlock;
	public Transform southBlock;
    public Transform farSouthBlock;
	public Transform westBlock;
    public Transform farWestBlock;

	public bool isCurrentBlock;
	public bool destroyOnJump;
	public bool readyToDestroy;
	public bool isAdjacentBlock;

	public bool isBlockTypeBlue;
    public Color blueGlow;
	public bool isBlockTypeRed;
    public Color redGlow;
	public bool isBlockTypeYellow;
    public Color yellowGlow;
	public bool isBlockTypePurple;
    public Color purpleGlow;
    public bool isBlockTypeCyan;
    public Color cyanGlow;

    public float scoreValue;
    public GameObject playerRef;
    public GameObject stageRef;

    public bool isProtected;

    public ParticleSystem defaultGlow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isProtected == true)
        {
            defaultGlow.enableEmission = true;
        }
        if (isProtected == false)
        {
            defaultGlow.enableEmission = false;
        }

        playerRef = GameObject.FindGameObjectWithTag("Player");
        stageRef = GameObject.FindObjectOfType<GameRefScript>();


        if (destroyOnJump == true && isCurrentBlock == true && isProtected == false) {
			readyToDestroy = true;
		}

		if (readyToDestroy == true && isCurrentBlock == false && isProtected == false) {
            playerRef.GetComponent<BasicPlayerScript>().playerScore += scoreValue;
			playerRef.GetComponent<BasicPlayerScript> ().powerUpScore += scoreValue;
            stageRef.GetComponent<GameRefScript>().stageScore += scoreValue;

            Destroy(gameObject);
		}

//        if (isBlockTypeBlue == true)
//        {
//            defaultGlow.GetComponent<ParticleSystem>().startColor = blueGlow;
//        }
//        if (isBlockTypeRed == true)
//        {
//            defaultGlow.GetComponent<ParticleSystem>().startColor = redGlow;
//        }
//        if (isBlockTypeYellow == true)
//        {
//            defaultGlow.GetComponent<ParticleSystem>().startColor = yellowGlow;
//        }
//        if (isBlockTypePurple == true)
//        {
//            defaultGlow.GetComponent<ParticleSystem>().startColor = purpleGlow;
//        }
//        if (isBlockTypeCyan == true)
//        {
//            defaultGlow.GetComponent<ParticleSystem>().startColor = cyanGlow;
//        }


        //		if (Input.GetMouseButtonDown(0)) {
        //			var hit: RaycastHit;
        //			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //
        //			if (Physics.Raycast(ray, hit)) {
        //				if (hit.transform.name == "MyObjectName" )Debug.Log( "My object is clicked by mouse");
        //			}
        //
        //	}


    }
}
