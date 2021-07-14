using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseButtonUI : MonoBehaviour
{
    [SerializeField] Button retryButton;

    private void Start()
    {
        int lives = FindObjectOfType<Master>().Lives();
        if (lives <= 0)
        {
            retryButton.interactable = false;
        }
        else
        {
            retryButton.interactable = true;
        }
    }
    public void Reload()
    {
        FindObjectOfType<Master>().LoseLife(); ;
        FindObjectOfType<LevelLoader>().LoadLostLevel();
      

    }
}
