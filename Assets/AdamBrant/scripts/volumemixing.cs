using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumemixing : MonoBehaviour {

    public AudioMixer masterMixer;

    public void SetSoundLvl(float soundLvl)
    {
        masterMixer.SetFloat("masterVolume", soundLvl);
    }


}
