using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    /*
     * Levels #'s for tracking who's who in the zoo
     * 0= Splash
     * 1=start
     * 2=Options
     * 3=Level 1
     * 4=Level 2
     * 5=Level 3
     * 6=Level 4
     * 7=WinGame
     * 8=Lose
     * 9=Level Trainer
     */
    //csi is short for current scene index
   [SerializeField] int csi;
    int lostlevelindex;
    Master m;
    
    // Start is called before the first frame update


 
    void Awake()
    {
        m = FindObjectOfType<Master>();
        csi = SceneManager.GetActiveScene().buildIndex;
       
        
       
       if (csi == 0)
        {
            StartCoroutine(WaitForTime());
           
        }
    }
   
    IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(m.WaitTime());
        LoadNextScene();
    }

    public void LoadTrainerScene()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadSplashScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadOptionsScene()
    {
        m.UpdateLastLevelAccessed(csi);
        SceneManager.LoadScene(2);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public int GetSceneID()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadFirstLevel()
    {
        if (m.GetTrainingStatus()==true)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
       
    }
    public void SetSceneID()
    {
        m.UpdateLastLevelAccessed(csi);
    }
   public void RestartGame()
    {
        Destroy(FindObjectOfType<Master>());
        SceneManager.LoadScene(0);
    }
    public void LoadNextScene()
    {
        csi++;
            SceneManager.LoadScene(csi);

    }
    //used for the Options Button to load up the last level you touched
    public void LoadReturnButtonUIScene()
    {
      
            SceneManager.LoadScene(m.LastLevelAccessed());

    } 

 public void LoadLostLevel()
    {
        SceneManager.LoadScene(m.GetLosePlayedLevel());
    }
    public void LoadLoseScene()
    {
        m.SetLoseplayedLevel(csi);
        SceneManager.LoadScene("Lose");

    }
    public int GetSceneInt()
    {
        return csi;
    }
}
