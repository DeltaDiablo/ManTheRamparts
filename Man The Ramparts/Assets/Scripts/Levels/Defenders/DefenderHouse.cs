using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderHouse : MonoBehaviour
{
    float health, starthealth;

    [SerializeField] float timekeeper, startTime,healthincrease;

    


    // Start is called before the first frame update
    void Start()
    {
        timekeeper = timekeeper * PlayerPrefsController.GetDifficulty();
        starthealth = GetComponent<Health>().Gethealth();
        health = starthealth;
        startTime = timekeeper; 

    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Health>().UpdateHealth();
        if (health < starthealth)
        {
            timekeeper -= Time.deltaTime;
            if(timekeeper <=0)
            {
                GetComponent<Health>().IncreaseHealth(healthincrease);
                timekeeper = startTime;
            }
        }
    }

    void OnDestroy()
    {
   //     FindObjectOfType<HouseCounterUI>().HouseDown();
    }
}
