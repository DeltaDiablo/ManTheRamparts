using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterUI : MonoBehaviour
{[Header("Timercounter in seconds")]
   
    [SerializeField] float timer = 4;

    Slider tmr;

    // Start is called before the first frame update
    void Start()
    {
        
        tmr = GetComponent<Slider>();
        tmr.maxValue = timer;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        tmr.value = timer;
      
      

    }
  
}
