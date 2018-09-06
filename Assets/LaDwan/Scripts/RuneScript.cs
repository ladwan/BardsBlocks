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
    public AudioClip Note1, Note2, Note3, Note4, Note5;
    public AudioSource SoundsSource;
    public ParticleSystem RuneGlow1, RuneGlow2, RuneGlow3, RuneGlow4, RuneGlow5;
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

            
        }
        StartCoroutine(SongOrder());
    }


    IEnumerator SongOrder()
    {
        yield return new WaitForSeconds(2);
        Rune5.GetComponent<Button>().enabled = true;
        SoundsSource.PlayOneShot(Note3);
        var glow = RuneGlow1.emission;
        glow.enabled = isglowing;
     

        yield return new WaitForSeconds(1);

        Rune2.GetComponent<Button>().enabled = true;
        Rune5.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(Note5);

        yield return new WaitForSeconds(1.2f);

        Rune1.GetComponent<Button>().enabled = true;
        Rune2.GetComponent<Button>().enabled = false;
        SoundsSource.PlayOneShot(Note4);


        yield return new WaitForSeconds(1);

        Rune1.GetComponent<Button>().enabled = false;
  

    }


    // Update is called once per frame
    void Update () {

        if (RunesCollected == 0 && PlayerRef.transform.position.x == WaterRune.transform.position.x && PlayerRef.transform.position.z == WaterRune.transform.position.z)
        {
            Rune5.GetComponent<Button>().enabled = true;
            RunesCollected++;
        }
        if (RunesCollected == 1 && PlayerRef.transform.position.x == FireRune.transform.position.x && PlayerRef.transform.position.z == FireRune.transform.position.z)
        {
            Rune2.GetComponent<Button>().enabled = true;
            RunesCollected++;
        }

        if (RunesCollected == 2 && PlayerRef.transform.position.x == AirRune.transform.position.x && PlayerRef.transform.position.z == AirRune.transform.position.z)
        {
            Rune1.GetComponent<Button>().enabled = true;
            RunesCollected = 0;
            CurrentStage = 2;
        }

        




    }
}
