using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CostScriptUI : MonoBehaviour
{
   public int cost;
    Text costText;
   public Defender product;
    // Start is called before the first frame update
    void Start()
    {
        cost = product.GetComponent<Defender>().ItemCost();
        GetComponent<TextMeshProUGUI>().text = cost.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
