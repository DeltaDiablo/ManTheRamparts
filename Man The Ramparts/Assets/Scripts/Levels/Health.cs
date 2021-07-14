using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float timer = 3;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject houseBurningVFX;
    [SerializeField] float deathTimer = 4f;
    float starthealth;
    // Start is called before the first frame update
    void Start()
    {
        starthealth = health;
    }
    public float Gethealth()
    {
        return health;
    }
    public float UpdateHealth()
    {
        return health;
    }
    public void IncreaseHealth(float amount)
    {
        health += amount;
    }
    public void DealDamage(float damage)
    {

        health -= damage;

        if (gameObject.GetComponent<DefenderHouse>()&&health>=0)
        {
            if (starthealth > health)
            {
                GameObject HouseVFXObject = Instantiate(houseBurningVFX, transform.position, transform.rotation);
                if (health <= 0||health==starthealth)
                {
                    Destroy(HouseVFXObject);
                }
            }
        }
        if (health <= 0)
        {
            if (gameObject.GetComponent<Attacker>())
            {
                if (!gameObject.name.Contains("GunPirateShip"))
                {
                    GetComponent<Animator>().SetBool("Sink", true);
                }
                TriggerDeathFX();
                Destroy(gameObject, timer);
            }
           
            if (gameObject.GetComponent<Defender>())
            {
                string eval = gameObject.transform.position.x.ToString() + "," + gameObject.transform.position.y.ToString();
                FindObjectOfType<DefenderSpawner>().listcontrol.Remove(eval);
                TriggerDeathFX();
                Destroy(gameObject);
            }
        }
    }

   private void TriggerDeathFX()
    {

        if (!deathVFX)
        {
            return;
        }
        else
        {

            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, deathTimer);

        }
      
    }
    
   
}
