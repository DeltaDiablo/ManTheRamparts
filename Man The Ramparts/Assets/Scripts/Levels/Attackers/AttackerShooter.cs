using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerShooter : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] AttackerProjectile shot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reduce health of attackers health in their health Script
        if (collision.GetComponent<Defender>())
        {
            if(!gameObject.name.Contains("VikingShip")||!gameObject.name.Contains("GunPirateShip"))
            GetComponent<Animator>().SetBool("Shoot", true);
        }
      

    }
    public void SpawnShot()
    {
        Instantiate(shot, firePoint.transform.position, firePoint.transform.rotation);
    }
    //get the shot position
    //create the shot
    
}
