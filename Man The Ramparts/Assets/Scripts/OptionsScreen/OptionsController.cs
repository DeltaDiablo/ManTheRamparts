using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [Header("Default Values")]
    [SerializeField] float defaultVolume,defaultDifficulty =1;
    // Start is called before the first frame update
    void Start()
    {
       volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        volumeSlider.onValueChanged.AddListener(delegate { SoundChangeCheck(); });
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        difficultySlider.onValueChanged.AddListener(delegate { DifficultyChangeCheck(); });
    }

    private void DifficultyChangeCheck()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    private void SoundChangeCheck()
    {
        var musicplayer = FindObjectOfType<MusicPlayer>();
        musicplayer.SetVolume(volumeSlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }
    public void SetLoadDefaultValues()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;

    }
   
}
