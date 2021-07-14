using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.volume = PlayerPrefsController.GetMasterVolume();

    }
   
       
    
    public void SetVolume(float volume)
    {
        audiosrc.volume = volume;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
