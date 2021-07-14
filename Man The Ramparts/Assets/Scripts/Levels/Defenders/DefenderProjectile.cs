using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProjectile : MonoBehaviour
{
    public int shotCost = 10;
    [SerializeField] float speed = 20;
    [SerializeField] float damage;
    [SerializeField] float shothealth = 10;
    public float volume;
    private void Awake()
    {
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetSFXVolume();
    }
    void Update()
    {
       
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public int ShotCost()
    {
        return shotCost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //reduce health of attackers health in their health Script
        var attack = collision.GetComponent<Attacker>();
        var healthcontrol = collision.GetComponent<Health>();
        if (attack && healthcontrol)
        {
               //get the health script of the collided item
                collision.GetComponent<Health>().DealDamage(damage);
                shothealth -= 10;
                if (shothealth <= 0)
                {
                    Destroy(gameObject);
                }
            
         
        }

    }
}
