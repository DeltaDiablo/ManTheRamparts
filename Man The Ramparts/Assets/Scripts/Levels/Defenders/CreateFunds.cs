using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFunds : MonoBehaviour
{
    [SerializeField] int income = 40;
public void AddFunds()
    {
        FindObjectOfType<Master>().Deposit(income);
    }
}
