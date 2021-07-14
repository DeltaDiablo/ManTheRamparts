using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonUI : MonoBehaviour
{


    public void LoadOptions()
    {
        LevelLoader ll = FindObjectOfType<LevelLoader>();
        ll.SetSceneID();
        ll.LoadOptionsScene();
    }
}
