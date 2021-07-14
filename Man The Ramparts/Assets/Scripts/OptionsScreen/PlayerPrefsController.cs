using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string SOUND_EFFECTS_KEY = "sound effects";
    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_SFX = 0f;
    const float MAX_SFX = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 3f;

    public static void SetMasterVolume(float volume)
    {if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        { PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume); }
        else { Debug.LogError("MASTER VOLUME OUT OF RANGE"); }
    }
    public static void SetSFXVolume(float effectsvol)
    {
        if (effectsvol >= MIN_SFX && effectsvol <= MAX_SFX)
        { PlayerPrefs.SetFloat(SOUND_EFFECTS_KEY, effectsvol); }
        else { Debug.LogError("MASTER SOUND EFFECTS OUT OF RANGE"); }
      
    }
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else { Debug.LogError("DIFFICULTY OUT OF RANGE"); }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_EFFECTS_KEY);
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
