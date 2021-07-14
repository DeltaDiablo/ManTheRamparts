using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FundsUI : MonoBehaviour
{
    int funds;
    Text fundText;
    // Start is called before the first frame update
    void Start()
    {
      funds =   FindObjectOfType<Master>().BankLimit();
        fundText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        funds = FindObjectOfType<Master>().BankLimit();
        fundText.text = funds.ToString();
    }
}
