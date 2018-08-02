using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerScript : MonoBehaviour {

    public Transform currentBlock;

    public GameObject camHolder;

    public float playerScore;
    public Animator A1,A2,B1,B3,C3;
    public Transform BlockA1, BlockA2, BlockB1, BlockB3, BlockC3;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(currentBlock == BlockA1)
        {
            A1.SetTrigger("A1");
        }
        else if (currentBlock == BlockA2)
        {
            A2.SetTrigger("A2");
        }
        else if (currentBlock == BlockB1)
        {
            B1.SetTrigger("B1");
        }
        else if (currentBlock == BlockB3)
        {
            B3.SetTrigger("B3");
        }
        else if (currentBlock == BlockC3)
        {
            C3.SetTrigger("C3");
        }
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
