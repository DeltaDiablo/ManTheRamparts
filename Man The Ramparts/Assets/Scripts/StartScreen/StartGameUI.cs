using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUI : MonoBehaviour
{
   public void GameStart()
    {
       int lvl = FindObjectOfType<LevelLoader>().GetSceneID();
        if (lvl != 7)
        {
            FindObjectOfType<LevelLoader>().LoadFirstLevel();
        }
        else
        {
            Destroy(FindObjectOfType<Master>(),1);
            FindObjectOfType<LevelLoader>().LoadSplashScene();

        }
    }
    public void OptionsMenu()
    {
       
        FindObjectOfType<LevelLoader>().LoadOptionsScene();
    }
    public void EndGame()
    {
        EndGame();
    }
    public void LoadMainScene()
    {
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
   
}
