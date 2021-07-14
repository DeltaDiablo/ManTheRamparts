using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextItemUI : MonoBehaviour
{
    [SerializeField] GameObject[] part;
    [SerializeField] bool traineractive = true;
    [SerializeField] int lvl = 0;
    [SerializeField] int records;
    [SerializeField] bool rtg=false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        if (traineractive == true)
        {
           
            gameObject.SetActive(true);
           // ButtonClick();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    //used on the Options screen to turn on/off trainer this defaults to on
    public void TrainerActive()
    {
        traineractive = false;
    }

    public void ButtonClick()
    {
        if (rtg == false)
        {
            try
            {
                GameObject[] parts = part;
                for (int i = 0; i < parts.Length; i++)
                {

                    if (lvl > 0)
                    {
                        parts[(lvl - 1)].SetActive(false);
                        parts[lvl].SetActive(true);
                        lvl++;
                        return;
                    }
                }
            }

            catch
            {
                GameObject g = GameObject.Find("NextButton");
                g.GetComponentInChildren<Text>().text = "Start Game";
                rtg = true;
                return;
            }
        }
        if (rtg)
        {
            StartGameNow();
        }

    }

    private void StartGameNow()
    {
        FindObjectOfType<Master>().UpdateTrainingStatus(false);
        FindObjectOfType<LevelLoader>().LoadFirstLevel();
    }

   
}
