using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherobject = collision.gameObject;

        if (otherobject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherobject);
        }
    }
}
