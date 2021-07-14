using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDeployerUI : MonoBehaviour
{
    [SerializeField] int funds, cost;
    public Defender defenderPrefab;
    Text textCost;
    //this button deploys the player items
    private void Start()
    {
        cost = defenderPrefab.ItemCost();
       
    }
    private void Update()
    {
     

        funds = FindObjectOfType<Master>().BankLimit();
        if (funds < defenderPrefab.ItemCost())
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);

        }
    }
   
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<ButtonDeployerUI>();
       foreach(ButtonDeployerUI button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255); 
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

   
}
