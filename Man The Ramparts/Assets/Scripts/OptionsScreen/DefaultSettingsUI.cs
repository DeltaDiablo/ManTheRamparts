using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSettingsUI : MonoBehaviour
{
  public void SetDefaultSettings()
    {
        FindObjectOfType<SFXController>().SetLoadDefaultValues();
        FindObjectOfType<OptionsController>().SetLoadDefaultValues();
    }
}
