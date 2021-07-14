using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RetryTextUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<Master>().Lives().ToString()+" TRIES LEFT";
        
    }
}
