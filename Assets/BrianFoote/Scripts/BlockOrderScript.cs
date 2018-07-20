using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockOrderScript : MonoBehaviour {

	public List <GameObject> songOrder = new List<GameObject> ();
	public int noteNumber;
	public int noteMax;

	public GameObject nextNote;

    public GameObject playerRef;
    public Transform currentBlockRef;
	public bool playerIsSafe;
    public bool playerIsDead;
    public bool playerCanWin;

	public bool wantTypeBlue;
	public bool wantTypeRed;
	public bool wantTypeYellow;
	public bool wantTypePurple;
    public bool wantTypeCyan;
    public Text currentColor;

	// Use this for initialization
	void Start () {
        playerCanWin = true;

		noteNumber = 0;
//		nextNote = songOrder[noteNumber];

	}
	
	// Update is called once per frame
	void Update () {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        if (playerIsDead == true)
        {
            playerCanWin = false;
            //Destroy (playerRef.GetComponent<BasicPlayerScript>().currentBlock);
            //Destroy(playerRef);
        }

        

        currentBlockRef = playerRef.GetComponent<BasicPlayerScript>().currentBlock;

//		noteNumber = 0;
		nextNote = songOrder[noteNumber];
		if (noteNumber == noteMax && playerCanWin == true) {
			Debug.Log ("Player wins!");
		}


		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeBlue && wantTypeBlue == true && playerIsSafe == false) {
			Debug.Log ("Player on blue");
            Debug.Log (noteNumber);

            wantTypeBlue = false;
			playerIsSafe = true;
			IncreaseNoteValue();
		}
		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeBlue && wantTypeBlue == false && playerIsSafe == false) {
			Debug.Log ("Player is Dead");
            playerIsDead = true;
		}
		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeRed && wantTypeRed == true && playerIsSafe == false) {
			Debug.Log ("Player on red");
            Debug.Log (noteNumber);

            wantTypeRed = false;
			playerIsSafe = true;
			IncreaseNoteValue();

		}
		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeRed && wantTypeRed == false && playerIsSafe == false) {
			Debug.Log ("Player is Dead");
            playerIsDead = true;

        }
        if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeYellow && wantTypeYellow == true && playerIsSafe == false) {
			Debug.Log ("Player on yellow");
            Debug.Log(noteNumber);

            wantTypeYellow = false;
			playerIsSafe = true;
			IncreaseNoteValue();

		}
		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeYellow && wantTypeYellow == false && playerIsSafe == false) {
			Debug.Log ("Player is Dead");
            playerIsDead = true;

        }
        if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypePurple && wantTypePurple == true && playerIsSafe == false) {
			Debug.Log ("Player on purple");
            Debug.Log(noteNumber);

            wantTypePurple = false;
			playerIsSafe = true;
			IncreaseNoteValue();

		}
		if (playerRef.GetComponent<BasicPlayerScript> ().currentBlock.GetComponent<BasicBlockScript> ().isBlockTypeCyan && wantTypeCyan == false && playerIsSafe == false) {
			Debug.Log ("Player is Dead");
            playerIsDead = true;

        }
        if (playerRef.GetComponent<BasicPlayerScript>().currentBlock.GetComponent<BasicBlockScript>().isBlockTypeCyan && wantTypeCyan == true && playerIsSafe == false)
        {
            Debug.Log("Player on cyan");
            Debug.Log(noteNumber);

            wantTypeCyan = false;
            playerIsSafe = true;
            IncreaseNoteValue();

        }
        if (playerRef.GetComponent<BasicPlayerScript>().currentBlock.GetComponent<BasicBlockScript>().isBlockTypePurple && wantTypePurple == false && playerIsSafe == false)
        {
            Debug.Log("Player is Dead");
            playerIsDead = true;

        }

        if (nextNote.GetComponent<BasicBlockScript> ().isBlockTypeBlue == true) {
			wantTypeBlue = true;
			wantTypeRed = false;
			wantTypeYellow = false;
			wantTypePurple = false;
            wantTypeCyan = false;


        }
        if (nextNote.GetComponent<BasicBlockScript> ().isBlockTypeRed == true) {
			wantTypeBlue = false;
			wantTypeRed = true;
			wantTypeYellow = false;
			wantTypePurple = false;
            wantTypeCyan = false;

        }
        if (nextNote.GetComponent<BasicBlockScript> ().isBlockTypeYellow == true) {
			wantTypeBlue = false;
			wantTypeRed = false;
			wantTypeYellow = true;
			wantTypePurple = false;
            wantTypeCyan = false;

        }
        if (nextNote.GetComponent<BasicBlockScript> ().isBlockTypePurple == true) {
			wantTypeBlue = false;
			wantTypeRed = false;
			wantTypeYellow = false;
			wantTypePurple = true;
            wantTypeCyan = false;
		}
        if (nextNote.GetComponent<BasicBlockScript>().isBlockTypeCyan == true)
        {
            wantTypeBlue = false;
            wantTypeRed = false;
            wantTypeYellow = false;
            wantTypePurple = false;
            wantTypeCyan = true;
        }

    }
	void IncreaseNoteValue(){
		noteNumber += 1;
	}
}
