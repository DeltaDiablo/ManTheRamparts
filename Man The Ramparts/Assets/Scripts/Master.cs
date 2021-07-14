using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{//llp is short for Last Level Played
    // ppl is short for previously played level
    [Header("Seconds to wait for loading next scene")]
    [SerializeField] float sTW = 5;
    [Header("Boublooms in the game")]
    [SerializeField] int funds = 1000;
    [Header("Master Lives in the game")]
    [SerializeField] int lives = 3;
    [Header("Last Level that was on")]
    [SerializeField] int llp;
    [Header("Previously Played Level")]
    [SerializeField] int ppl;
    [Header("Last Level accessed")]
    [SerializeField] int lla;
    [Header("Training functions")]
    [SerializeField] bool trainerStatus;
 
    
    void Awake()
    {
        //this allows us to keep the values that enable info to be passed from one scene to another
        if (FindObjectsOfType<MasterScript>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void UpdateTrainingStatus(bool stat)
    {
        trainerStatus = stat;
    }
    public bool GetTrainingStatus()
    {
        return trainerStatus;
    }
    public void UpdateLastLevelAccessed(int level)
    {
        lla = level;
    }
    public int LastLevelAccessed()
    {
        return lla;
    }
    public int Lives()
    {
        return lives;
    }
    public int BankLimit()
    {
        return funds;
    }
   public float WaitTime()
    {
        return sTW;
    }
    public void Withdrawal(int amount)
    {
        funds -= amount;
    }
    public void CurrentLevel(int level)
    {
        llp = level;
    }
    public void Deposit(int amount)
    {
        funds += amount;
    }
    public void LoseLife()
    {
        lives--;
    }
  
    public void SetLoseplayedLevel(int level)
    {
        ppl = level;
    }
   public int GetLosePlayedLevel()
    {
        return ppl;
    }
    public int GetLastLevelPlayed()
    {
        return llp;
    }
   
 
}
