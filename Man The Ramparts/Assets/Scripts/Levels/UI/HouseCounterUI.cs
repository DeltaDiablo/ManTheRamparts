using UnityEngine;
using UnityEngine.UI;

public class HouseCounterUI : MonoBehaviour
{
    [SerializeField ]int housecount, starthousecount, retries;
    [SerializeField]Text retry,houses;
    // Start is called before the first frame update
    private void Start()
    {
        CounterWork();
    }

    // Update is called once per frame
    void Update()
    {
        CounterWork();
    }
    private void CounterWork()
    {
        retries = FindObjectOfType<Master>().Lives();
        housecount = FindObjectsOfType<DefenderHouse>().Length;
        starthousecount = housecount;
        if (!retry) 
        { 
            houses.text = housecount.ToString();
            if (housecount <= 0)
            {
                FindObjectOfType<MasterScript>().HandleLoseCondition();
            }
        }

        if (!houses)
        {
            retry.text = retries.ToString();
        }
     
    }
 
   
   public void HouseDown()
    {
        housecount--;
    }
}
