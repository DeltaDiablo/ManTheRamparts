using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAvailableUI : MonoBehaviour
{
    [SerializeField] int funds,cost;
    Defender G;
    Master M;

    // Update is called once per frame
    void Update()
    {
        G = GetComponent<ButtonDeployerUI>().defenderPrefab;
        M = FindObjectOfType<Master>();
        cost = G.ItemCost();
        funds = M.BankLimit();
        if (funds < cost)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);

        }
        else if(funds>cost)
        {
            GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }
    }
}
