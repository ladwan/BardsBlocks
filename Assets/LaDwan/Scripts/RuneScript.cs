using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneScript : MonoBehaviour {
    public GameObject Rune1, Rune2, Rune3, Rune4, Rune5;
    int CurrentStage = 1, RunesCollected = 0;
    GameObject NextNoteREF;
    Transform CurrentBlockREF,REFtransform;
    public GameObject WaterRune, FireRune, AirRune;
    public GameObject PlayerRef;
    public AudioClip Note1, Note2, WaterNote, ArrowNote, FireNote;
    public AudioSource SoundsSource;
    public GameObject RuneGlow1, RuneGlow2, WaterParticle, ArrowParticle, FireParticle;
    public bool isglowing;
    // Use this for initialization
    void Start () {
        if (CurrentStage == 1)
        {
            Rune3.SetActive(false);
            Rune4.SetActive(false);

            Rune1.GetComponent<Button>().enabled = false;
            Rune2.GetComponent<Button>().enabled = false;
            Rune5.GetComponent<Button>().enabled = false;
            WaterParticle.SetActive(false);
            ArrowParticle.SetActive(false);
            FireParticle.SetActive(false);
            
        }
        StartCoroutine(SongOrder());
    }


    IEnumerator SongOrder()
    {
        yield return new WaitForSeconds(2);
        Rune5.GetComponent<Button>().enabled = true;
        SoundsSource.PlayOneShot(WaterNote);
        WaterParticle.SetActive(true);
     

        yield return new WaitForSeconds(1);

        Rune2.GetComponent<Button>().enabled = true;
        Rune5.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(FireNote);
        FireParticle.SetActive(true);

        yield return new WaitForSeconds(1.2f);

        Rune1.GetComponent<Button>().enabled = true;
        Rune2.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(ArrowNote);
        ArrowParticle.SetActive(true);


        yield return new WaitForSeconds(1);

        Rune1.GetComponent<Button>().enabled = false;
  

    }


    // Update is called once per frame
    void Update () {

        if (RunesCollected == 0 && PlayerRef.transform.position.x == WaterRune.transform.position.x && PlayerRef.transform.position.z == WaterRune.transform.position.z)
        {
            Rune5.GetComponent<Button>().enabled = true;
            RunesCollected++;
            WaterParticle.SetActive(false);
        }
        if (RunesCollected == 1 && PlayerRef.transform.position.x == FireRune.transform.position.x && PlayerRef.transform.position.z == FireRune.transform.position.z)
        {
            Rune2.GetComponent<Button>().enabled = true;
            RunesCollected++;
            FireParticle.SetActive(false);
        }

        if (RunesCollected == 2 && PlayerRef.transform.position.x == AirRune.transform.position.x && PlayerRef.transform.position.z == AirRune.transform.position.z)
        {
            Rune1.GetComponent<Button>().enabled = true;
            ArrowParticle.SetActive(false);
            RunesCollected = 0;
            CurrentStage = 2;
        }

        




    }
}
