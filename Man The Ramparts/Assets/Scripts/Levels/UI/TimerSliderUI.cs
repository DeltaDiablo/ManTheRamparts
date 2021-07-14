using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerSliderUI : MonoBehaviour
{
    [Tooltip("Timer in SECONDS!")]
    [SerializeField] float leveltime = 10;
    bool triggerlevelfinished = false;
    // Update is called once per frame
    void Update()
    {
        if (triggerlevelfinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / leveltime;

        bool timerfinished = (Time.timeSinceLevelLoad >= leveltime);
        if (timerfinished)
        {
            //triggers when timer is expired
            FindObjectOfType<MasterScript>().LevelTimerFinished();
            triggerlevelfinished = true;
        }
    }
}
