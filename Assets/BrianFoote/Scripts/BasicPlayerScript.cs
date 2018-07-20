using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerScript : MonoBehaviour {

	public Transform currentBlock;

	public GameObject camHolder;

    public float playerScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;

		gameObject.transform.position = new Vector3 (currentBlock.position.x, 1.3f, currentBlock.position.z);

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().northBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().eastBlock ||
					hit.transform == currentBlock.GetComponent<BasicBlockScript>().southBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().westBlock) {
					Debug.Log (hit.transform.gameObject);
                    currentBlock.GetComponent<BasicBlockScript> ().isCurrentBlock = false;
					currentBlock = hit.transform;
					currentBlock.GetComponent<BasicBlockScript> ().isCurrentBlock = true;
					JumpSpace ();
				}
			}
		}
		
	}

	void JumpSpace(){
		if (FindObjectOfType<BlockOrderScript> ().playerIsSafe == true) {
			FindObjectOfType<BlockOrderScript> ().playerIsSafe = false;
		}
	}
}
