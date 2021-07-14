using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasUI : MonoBehaviour
{
    float wt;
    // Start is called before the first frame update
    void Start()
    {
        wt = FindObjectOfType<Master>().WaitTime();
        StartCoroutine(LoadNextScene());
        
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(wt);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
   
}
