using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerScript : MonoBehaviour {

	public GameObject scoreReference;

	public Transform currentBlock;

	public GameObject camHolder;

    public float playerScore;

	public float powerUpScore;

	public float powerUpScoreThresh;

	public float doubleJumpUseCount;
    public float doubleJumpUseMax;

    public float protectUseCount;
    public float protectUseMax;

    public int powerUpPickNumber;

    public bool canDoubleJump;
    public GameObject canDoubleJumpMark;
    public bool canProtect;
    public GameObject canProtectMark;

    //public bool farJumpActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		scoreReference = GameObject.FindGameObjectWithTag ("ScoreReference");

        if (doubleJumpUseCount >= 1)
        {
            canDoubleJump = true;
            canDoubleJumpMark.SetActive(true);
        }

        if (doubleJumpUseCount == 0)
        {
            canDoubleJump = false;
            canDoubleJumpMark.SetActive(false);
        }

        if (doubleJumpUseCount > doubleJumpUseMax)
        {
            doubleJumpUseCount = doubleJumpUseMax;
        }

        if (protectUseCount >= 1)
        {
            canProtect = true;
            canProtectMark.SetActive(true);
        }

        if (protectUseCount == 0)
        {
            canProtect = false;
            canProtectMark.SetActive(false);
        }

        if (protectUseCount > protectUseMax)
        {
            protectUseCount = protectUseMax;
        }
//
//        if (powerUpScore >= powerUpScoreThresh) 
//		{
//			powerUpScore = 0;
//			doubleJumpUseCount += 1;
//            protectUseCount += 1;
//		}

        currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;

		gameObject.transform.position = new Vector3 (currentBlock.position.x, 1.3f, currentBlock.position.z);

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().northBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().eastBlock ||
					hit.transform == currentBlock.GetComponent<BasicBlockScript>().southBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().westBlock) {
//					Debug.Log (hit.transform.gameObject);
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
//                    Debug.Log(hit.transform.gameObject);
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

    public void RandomInt()
    {
        powerUpPickNumber = Random.Range(1, 3);
        if (powerUpPickNumber == 1)
        {
            IncreaseDoubleJump();
        }
        if (powerUpPickNumber == 2)
        {
            IncreaseProtect();
        }
    }

    public void IncreaseDoubleJump()
    {
        //doubleJumpUseCount += 1;
        //protectUseCount += 1;

        if (powerUpPickNumber == 1 && doubleJumpUseCount == doubleJumpUseMax)
        {
            protectUseCount += 1;
        }
        if (powerUpPickNumber == 1 && doubleJumpUseCount < doubleJumpUseMax)
        {
           doubleJumpUseCount += 1;
        }
        

        
    }
    public void IncreaseProtect()
    {
        if (powerUpPickNumber == 2 && protectUseCount == protectUseMax)
        {
            doubleJumpUseCount += 1;
        }
        if (powerUpPickNumber == 2 && protectUseCount < protectUseMax)
        {
            protectUseCount += 1;
        }
        
    }


}
