using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.volume = PlayerPrefsController.GetMasterVolume();

    }
    public void SetSFX()
    {
        FindObjectOfType<DefenderProjectile>().volume = PlayerPrefsController.GetSFXVolume();
        FindObjectOfType<AttackerProjectile>().volume = PlayerPrefsController.GetSFXVolume();
    }
    public void SetVolume(float volume)
    {
        audiosrc.volume = volume;
        audiosrc.Play();
    }

}
