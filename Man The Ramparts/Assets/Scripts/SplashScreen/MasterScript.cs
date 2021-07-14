using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public GameObject WinLabel;
    int numberOfAttackers;
    bool leveltimerfinished = false;
    Master master;
    int lostLevel;
    
   
    
    
    private void Start()
    {
        Time.timeScale = 1;
        master = FindObjectOfType<Master>();
      try
        {
            WinLabel.SetActive(false);
        }
        catch { return; }
      
     
    }
  
    public void SpendFunds(int amount) 
    {
       
        int funds = master.BankLimit();
        if(funds >=amount)
            master.Withdrawal(amount);
    }
    public bool HaveEnoughFunds(int amount)
    { 
        return master.BankLimit() >= amount;
    }
   
   public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (leveltimerfinished&& numberOfAttackers <= 0)
        {
            StartCoroutine(HandleWinCondition()); 
        }
        
    }

   
    public int LostLevel()
    {
        return lostLevel;
    }
    public void HandleLoseCondition()
    {
        int l =FindObjectOfType<LevelLoader>().GetSceneInt();
        lostLevel = l;
        master.SetLoseplayedLevel(l);
        FindObjectOfType<LevelLoader>().LoadLoseScene();
    }
 
    IEnumerator HandleWinCondition()
    {
        WinLabel.SetActive(true);
        yield return new WaitForSeconds(master.WaitTime());
        WinLabel.SetActive(false);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        leveltimerfinished = true;
        StopSpawners();
    }
    private void StopSpawners()
    {
        FindObjectOfType<AttackerSpawner>().StopSpawning();
    }
}
