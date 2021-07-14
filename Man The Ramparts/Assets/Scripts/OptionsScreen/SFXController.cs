using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [Header("Default Values")]
    [SerializeField] float defaultSFX;
    // Start is called before the first frame update
    void Start()
    {
        sfxSlider.value = PlayerPrefsController.GetSFXVolume();
        sfxSlider.onValueChanged.AddListener(delegate { SFXChangeCheck(); });
    }
  
    private void SFXChangeCheck()
    {
        var sfxPlayer = FindObjectOfType<SFXPlayer>();
        sfxPlayer.SetVolume(sfxSlider.value);
        PlayerPrefsController.SetSFXVolume(sfxSlider.value);
    }
    public void SetLoadDefaultValues()
    {
        sfxSlider.value = defaultSFX;

    }
   
}
