using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonUI : MonoBehaviour
{
    public void LoadMain()
    {
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    
    }
}
