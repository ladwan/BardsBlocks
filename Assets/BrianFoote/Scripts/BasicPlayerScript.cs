using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlayerScript : MonoBehaviour {

	public GameObject scoreReference;

	public Transform currentBlock;

	public GameObject camHolder;

    public GameObject pauseMenu;

    public float playerScore;

	public float powerUpScore;

	public float powerUpScoreThresh;

	public float doubleJumpUseCount;
    public float doubleJumpUseMax;

    public float protectUseCount;
    public float protectUseMax;

    public int powerUpPickNumber;

    public bool canDoubleJump;
    public GameObject doubleJumpButton;
	public bool doubleJumpActive;
	public GameObject doubleJumpActiveIndic;
    public Sprite doubleJumpPotionFull;
    public Sprite doubleJumpPotionEmpty;

    public bool canProtect;
    public GameObject protectButton;
	public bool protectActive;
	public GameObject protectActiveIndic;
    public Sprite protectPotionFull;
    public Sprite protectPotionEmpty;


    public Animator A1, A2, B1, B3, C3;
    public Transform BlockA1, BlockA2, BlockB1, BlockB3, BlockC3;

    // Use this for initialization
    void Start()
    {

        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");


    }



    // Update is called once per frame
    void Update () {
        if (pauseMenu.GetComponent<PauseScript>().isPaused == false)
        {

            if (currentBlock == BlockA1)
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


            //		scoreReference = GameObject.FindGameObjectWithTag ("ScoreReference");

            if (doubleJumpUseCount >= 1)
            {

                canDoubleJump = true;
                doubleJumpButton.GetComponent<Image>().sprite = doubleJumpPotionFull;
                doubleJumpButton.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (doubleJumpUseCount == 0)
            {
                canDoubleJump = false;
                doubleJumpButton.GetComponent<Image>().sprite = doubleJumpPotionEmpty;
                doubleJumpButton.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (doubleJumpUseCount > doubleJumpUseMax)
            {
                doubleJumpUseCount = doubleJumpUseMax;
            }

            if (protectUseCount >= 1)
            {
                canProtect = true;
                protectButton.GetComponent<Image>().sprite = protectPotionFull;
                protectButton.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (protectUseCount == 0)
            {
                canProtect = false;
                protectButton.GetComponent<Image>().sprite = protectPotionEmpty;
                protectButton.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (protectUseCount > protectUseMax)
            {
                protectUseCount = protectUseMax;
            }

            if (doubleJumpActive == true)
            {
                doubleJumpActiveIndic.SetActive(true);
            }

            if (doubleJumpActive == false)
            {
                doubleJumpActiveIndic.SetActive(false);
            }

            if (protectActive == true)
            {
                protectActiveIndic.SetActive(true);
            }
            if (protectActive == false)
            {
                protectActiveIndic.SetActive(false);
            }

            //
            //        if (powerUpScore >= powerUpScoreThresh) 
            //		{
            //			powerUpScore = 0;
            //			doubleJumpUseCount += 1;
            //            protectUseCount += 1;
            //		}

            currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;
            gameObject.transform.position = new Vector3(currentBlock.position.x, 2f, currentBlock.position.z);
            if (Input.GetMouseButtonDown(0) && doubleJumpActive == false && protectActive == false)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform == currentBlock.GetComponent<BasicBlockScript>().northBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().eastBlock ||
                        hit.transform == currentBlock.GetComponent<BasicBlockScript>().southBlock || hit.transform == currentBlock.GetComponent<BasicBlockScript>().westBlock)
                    {
                        //					Debug.Log (hit.transform.gameObject);
                        currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = false;
                        currentBlock = hit.transform;
                        currentBlock.GetComponent<BasicBlockScript>().isCurrentBlock = true;
                        if (currentBlock.GetComponent<BasicBlockScript>().isProtected == true)
                        {
                            currentBlock.GetComponent<BasicBlockScript>().isProtected = false;
                        }
                        JumpSpace();
                    }
                }

            }

            if (Input.GetMouseButtonDown(0) && doubleJumpActive == true && protectActive == false)
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
                        doubleJumpActive = false;
                    }


                }
            }

            if (Input.GetMouseButtonDown(0) && doubleJumpActive == false && protectActive == true)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit, 100.0f) && canProtect == true)
                {


                    if (hit.transform == currentBlock && canProtect == true && currentBlock.GetComponent<BasicBlockScript>().isProtected == false && currentBlock.GetComponent<BasicBlockScript>().destroyOnJump == true)
                    {
                        currentBlock.GetComponent<BasicBlockScript>().isProtected = true;
                        protectUseCount -= 1;
                        protectActive = false;
                    }
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

	public void ActivateDoubleJump(){
		protectActive = false;
		if (doubleJumpActive == true) {
			doubleJumpActive = false;
		} 
		else
		doubleJumpActive = true;

	}

	public void ActivateProtect(){
		doubleJumpActive = false;
		if (protectActive == true) {
			protectActive = false;
		} 
		else
		protectActive = true;

		
	}


}
