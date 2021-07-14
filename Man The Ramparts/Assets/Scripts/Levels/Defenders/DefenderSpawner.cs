using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";
    GameObject defenderParent;
     Defender defender;
    public List<string> listcontrol;
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
       
        {
           AttemptToPlaceDefenderAt(GetSquareClicked());
        }

    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
            defender = defenderToSelect;
    }
  
    private void AttemptToPlaceDefenderAt(Vector2 gridpos)
    {
        var getfunds = FindObjectOfType<MasterScript>();
        try
        {
            int defendercost = defender.ItemCost();
            if (getfunds.HaveEnoughFunds(defendercost))
            {
                SpawnDefender(gridpos);
                getfunds.SpendFunds(defendercost);
            }
        }
        catch
        {
            return;
        }
        
       
    }

    private void SpawnDefender(Vector2 whereToSpawnPos)
    {
        string eval = whereToSpawnPos.x.ToString() + "," + whereToSpawnPos.y.ToString();
        if (!listcontrol.Contains(eval))
        {
            Defender newDefender = Instantiate(defender, whereToSpawnPos, Quaternion.identity) as Defender;
            newDefender.transform.parent = defenderParent.transform;
            
            listcontrol.Add(eval);
        }

    }
    private Vector2 SnapToGrid(Vector2 snaptogridPos)
    {
        float xval = Mathf.RoundToInt(snaptogridPos.x);
        float yval = Mathf.RoundToInt(snaptogridPos.y);

        return new Vector2(xval, yval);
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickpos = new Vector2((Input.mousePosition.x),(Input.mousePosition.y));
        Vector2 snaptogridpos = Camera.main.ScreenToWorldPoint(clickpos);
        Vector2 worldpos = SnapToGrid(snaptogridpos);

        return worldpos;
    }
}
