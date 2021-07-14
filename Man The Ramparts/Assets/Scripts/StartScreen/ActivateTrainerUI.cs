using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActivateTrainerUI : MonoBehaviour
{
    [SerializeField] bool ts;
    // Start is called before the first frame update

    void Start()
    {
        GetStatus();
    }

    public void TrainerStatChange()
    {
        ChangeTrainer();
        
    }
    private void GetStatus()
    {
        ts = FindObjectOfType<Master>().GetTrainingStatus();
        if (ts == false)
        {
            GetComponent<TextMeshProUGUI>().text = "Go To Game!";         
        }
        else if (ts == true)
        {
            GetComponent<TextMeshProUGUI>().text = "How to Play";
        }
    }
    public void ChangeTrainer()
    {
        if (FindObjectOfType<Master>().GetTrainingStatus())
        {
            FindObjectOfType<Master>().UpdateTrainingStatus(false);
            GetStatus();
        }
        else if (FindObjectOfType<Master>().GetTrainingStatus()==false)
        {
            FindObjectOfType<Master>().UpdateTrainingStatus(true);
            GetStatus();
        }

    }
}
