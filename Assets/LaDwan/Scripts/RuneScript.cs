using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneScript : MonoBehaviour {
    public GameObject Rune1, Rune2, Rune3, Rune4, Rune5;
    int CurrentStage = 1, RunesCollected = 0;
    GameObject NextNoteREF;
    Transform CurrentBlockREF;
    public GameObject WaterRune, FireRune, AirRune;

    
	// Use this for initialization
	void Start () {
        if (CurrentStage == 1)
        {
            Rune3.SetActive(false);
            Rune4.SetActive(false);

            Rune1.GetComponent<Button>().enabled = false;
            Rune2.GetComponent<Button>().enabled = false;
            Rune5.GetComponent<Button>().enabled = false;


        }
        StartCoroutine(SongOrder());
    }
	
    IEnumerator SongOrder()
    {
        yield return new WaitForSeconds(2);
        Rune5.GetComponent<Button>().enabled = true;
        yield return new WaitForSeconds(1);
        Rune2.GetComponent<Button>().enabled = true;
        Rune5.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(1);
        Rune1.GetComponent<Button>().enabled = true;
        Rune2.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(1);
        Rune1.GetComponent<Button>().enabled = false;
        StartCoroutine(RuneCollectionCheck());

    }

    IEnumerator RuneCollectionCheck()
    {
        yield return new WaitForSeconds(1);
        if (RunesCollected == 0 && gameObject.transform == WaterRune.transform)
        {
            Rune5.GetComponent<Button>().enabled = true;
            RunesCollected++;
        }
        if (RunesCollected == 1 && gameObject.transform == FireRune.transform)
        {
            Rune5.GetComponent<Button>().enabled = true;
            RunesCollected++;
        }

        if (RunesCollected == 2 && gameObject.transform == AirRune.transform)
        {
            Rune5.GetComponent<Button>().enabled = true;
            RunesCollected = 0;
            CurrentStage = 2;
        }
    }
    // Update is called once per frame
    void Update () {

        if (gameObject.transform.hasChanged)
        {
            StartCoroutine(RuneCollectionCheck());
        }





        

    }
}
