using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonUI : MonoBehaviour
{
  public void ReturnToLastScreen()
    {
        FindObjectOfType<LevelLoader>().LoadReturnButtonUIScene();
    }
}
