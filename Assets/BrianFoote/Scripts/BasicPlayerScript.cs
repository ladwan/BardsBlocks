using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerScript : MonoBehaviour {

	public Transform currentBlock;

	public GameObject camHolder;

    public float playerScore;

	public float powerUpScore;

	public float powerUpScoreThresh;

	public float powerUpUseCount;

    public bool canUsePowerUp;

    public bool farJumpActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (powerUpUseCount >= 1)
        {
            canUsePowerUp = true;
        }

        if (powerUpUseCount == 0)
        {
            canUsePowerUp = false;
        }

		if (powerUpScore >= powerUpScoreThresh) 
		{
			powerUpScore = 0;
			powerUpUseCount += 1;
		}

        currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;

		gameObject.transform.position = new Vector3 (currentBlock.position.x, 1.3f, currentBlock.position.z);

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100.0f) && farJumpActive == false) {
				if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().northBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().eastBlock ||
					hit.transform == currentBlock.GetComponent<BasicBlockScript>().southBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().westBlock) {
					Debug.Log (hit.transform.gameObject);
                    currentBlock.GetComponent<BasicBlockScript> ().isCurrentBlock = false;
					currentBlock = hit.transform;
					currentBlock.GetComponent<BasicBlockScript> ().isCurrentBlock = true;
                    if (currentBlock.GetComponent<BasicBlockScript>().isProtected == true)
                    {
                        currentBlock.GetComponent<BasicBlockScript>().isProtected = false;
                    }
					JumpSpace ();
				}
			}
            
        }

        if (Input.GetMouseButtonDown(1))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit, 100.0f) && canUsePowerUp == true)
            {
                if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().farNorthBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().farEastBlock ||
                    hit.transform == currentBlock.GetComponent<BasicBlockScript>().farSouthBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().farWestBlock)
                {
                    Debug.Log(hit.transform.gameObject);
                    currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = false;
                    currentBlock = hit.transform;
                    currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;
                    JumpSpace();
                    powerUpUseCount -= 1;
                    farJumpActive = false;
                }

                if (hit.transform == currentBlock && canUsePowerUp == true)
                {
                    currentBlock.GetComponent<BasicBlockScript>().isProtected = true;
                    powerUpUseCount -= 1;
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
