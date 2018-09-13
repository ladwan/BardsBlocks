using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneScript3 : MonoBehaviour
{
    public GameObject WaterButton, EarthButton, FireButton, SheildButton, ArrowButton;
    int CurrentStage = 3, RunesCollected = 0;
    GameObject NextNoteREF;
    Transform CurrentBlockREF, REFtransform;
    public GameObject WaterRune, FireRune, ArrowRune, EarthRune, ShieldRune;
    public GameObject PlayerRef;
    public AudioClip SheildNote, EarthNote, WaterNote, ArrowNote, FireNote;
    public AudioSource SoundsSource;
    public GameObject EarthParticle, SheildParticle, WaterParticle, ArrowParticle, FireParticle;
    public bool isglowing;
    // Use this for initialization
    void Start()
    {
        if (CurrentStage == 3)
        {




            ArrowButton.GetComponent<Button>().enabled = false;
            WaterButton.GetComponent<Button>().enabled = false;
            EarthButton.GetComponent<Button>().enabled = false;
            SheildButton.GetComponent<Button>().enabled = false;
            FireButton.GetComponent<Button>().enabled = false;
            WaterParticle.SetActive(false);
            SheildParticle.SetActive(false);
            FireParticle.SetActive(false);
            EarthParticle.SetActive(false);
            ArrowParticle.SetActive(false);


        }
        StartCoroutine(SongOrder());
    }


    IEnumerator SongOrder()
    {
        yield return new WaitForSeconds(2);
        EarthButton.GetComponent<Button>().enabled = true;
        SoundsSource.PlayOneShot(EarthNote);
        EarthParticle.SetActive(true);


        yield return new WaitForSeconds(1);

        WaterButton.GetComponent<Button>().enabled = true;
        EarthButton.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(WaterNote);
        WaterParticle.SetActive(true);

        yield return new WaitForSeconds(1.2f);

        FireButton.GetComponent<Button>().enabled = true;
        WaterButton.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(FireNote);
        FireParticle.SetActive(true);


        yield return new WaitForSeconds(1.2f);

        ArrowButton.GetComponent<Button>().enabled = true;
        FireButton.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(ArrowNote);
        ArrowParticle.SetActive(true);

        yield return new WaitForSeconds(1.2f);

       SheildButton.GetComponent<Button>().enabled = true;
        ArrowButton.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(SheildNote);
        SheildParticle.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        SheildButton.GetComponent<Button>().enabled = false;






    }


    // Update is called once per frame
    void Update()
    {

        if (RunesCollected == 0 && PlayerRef.transform.position.x == EarthRune.transform.position.x && PlayerRef.transform.position.z == EarthRune.transform.position.z)
        {
            EarthButton.GetComponent<Button>().enabled = true;
            RunesCollected++;
            EarthParticle.SetActive(false);
        }
        if (RunesCollected == 1 && PlayerRef.transform.position.x == WaterRune.transform.position.x && PlayerRef.transform.position.z == WaterRune.transform.position.z)
        {
            WaterButton.GetComponent<Button>().enabled = true;
            RunesCollected++;
            WaterParticle.SetActive(false);
        }

        if (RunesCollected == 2 && PlayerRef.transform.position.x == FireRune.transform.position.x && PlayerRef.transform.position.z == FireRune.transform.position.z)
        {
            FireButton.GetComponent<Button>().enabled = true;
            FireParticle.SetActive(false);
            RunesCollected++;

        }

        if (RunesCollected == 3 && PlayerRef.transform.position.x == ArrowRune.transform.position.x && PlayerRef.transform.position.z == ArrowRune.transform.position.z)
        {
            ArrowButton.GetComponent<Button>().enabled = true;
            ArrowParticle.SetActive(false);
            RunesCollected++;
            

        }
        if (RunesCollected == 4 && PlayerRef.transform.position.x == ShieldRune.transform.position.x && PlayerRef.transform.position.z == ShieldRune.transform.position.z)
        {
            SheildButton.GetComponent<Button>().enabled = true;
            SheildParticle.SetActive(false);
            RunesCollected++;


        }





    }
}
