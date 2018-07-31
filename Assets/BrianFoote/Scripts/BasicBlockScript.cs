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
	public bool isBlockTypeRed;
	public bool isBlockTypeYellow;
	public bool isBlockTypePurple;
    public bool isBlockTypeCyan;

    public float scoreValue;
    public GameObject playerRef;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerRef = GameObject.FindGameObjectWithTag("Player");


        if (destroyOnJump == true && isCurrentBlock == true) {
			readyToDestroy = true;
		}

		if (readyToDestroy == true && isCurrentBlock == false) {
            playerRef.GetComponent<BasicPlayerScript>().playerScore += scoreValue;

            Destroy(gameObject);
		}


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
