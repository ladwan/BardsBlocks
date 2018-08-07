using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerScript : MonoBehaviour {

	public Transform currentBlock;

	public GameObject camHolder;

    public float playerScore;

	public float powerUpScore;

	public float powerUpScoreThresh;

	public float doubleJumpUseCount;
    public float doubleJumpUseMax;

    public float protectUseCount;
    public float protectUseMax;

    public bool canDoubleJump;
    public bool canProtect;

    //public bool farJumpActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (doubleJumpUseCount >= 1)
        {
            canDoubleJump = true;
        }

        if (doubleJumpUseCount == 0)
        {
            canDoubleJump = false;
        }

        if (doubleJumpUseCount > doubleJumpUseMax)
        {
            doubleJumpUseCount = doubleJumpUseMax;
        }

        if (protectUseCount >= 1)
        {
            canProtect = true;
        }

        if (protectUseCount == 0)
        {
            canProtect = false;
        }

        if (protectUseCount > protectUseMax)
        {
            protectUseCount = protectUseMax;
        }

        if (powerUpScore >= powerUpScoreThresh) 
		{
			powerUpScore = 0;
			doubleJumpUseCount += 1;
            protectUseCount += 1;
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

            
            if (Physics.Raycast(ray, out hit, 100.0f) && canDoubleJump == true)
            {
                if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().farNorthBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().farEastBlock ||
                    hit.transform == currentBlock.GetComponent<BasicBlockScript>().farSouthBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().farWestBlock)
                {
                    Debug.Log(hit.transform.gameObject);
                    currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = false;
                    currentBlock = hit.transform;
                    currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;
                    if (currentBlock.GetComponent<BasicBlockScript>().isProtected == true)
                    {
                        currentBlock.GetComponent<BasicBlockScript>().isProtected = false;
                    }
                    JumpSpace();
                    doubleJumpUseCount -= 1;
                    //farJumpActive = false;
                }

                
            }
        }

        if (Input.GetMouseButtonDown(2))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f) && canProtect == true)
            {
                

                if (hit.transform == currentBlock && canProtect == true && currentBlock.GetComponent<BasicBlockScript>().isProtected == false && currentBlock.GetComponent<BasicBlockScript>().destroyOnJump == true)
                {
                    currentBlock.GetComponent<BasicBlockScript>().isProtected = true;
                    protectUseCount -= 1;
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
