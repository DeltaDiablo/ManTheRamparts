using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour
{
    [SerializeField] GameObject[] firePoint;
    [SerializeField] DefenderProjectile[] shotarray;
    [SerializeField] int shotcost = 0;
    Attacker  myLaneSpawner;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    int totcost;
    // Start is called before the first frame update
    void Start()
    {
      
        GetShotCost();
        CreateprojectileParent();

    }

    private void CreateprojectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
           Shooting();
        }
        else
        {
            SetlaneSpawner();
            NotShooting();
        }
    }

   
    private bool IsAttackerInLane()
    {
        if (!myLaneSpawner)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

  


  
   private void SetlaneSpawner()
    {
        Attacker[] spawners = FindObjectsOfType<Attacker>();
        foreach(Attacker spawner in spawners)
        {
          
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - gameObject.transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
               
              
            }
            else
            {
                
            }
        }
    }
  private void Shooting()
    {

            GetComponent<Animator>().SetBool("Shoot", true);
        
    }
    private void NotShooting()
    {
        GetComponent<Animator>().SetBool("Shoot", false);
    }
    private void GetShotCost()
    {
        foreach(DefenderProjectile p in shotarray)
        {
            shotcost += p.GetComponent<DefenderProjectile>().ShotCost();
        }
    }
    public void Fire()
    {
        StartCoroutine(ReleaseShot());

    }
    IEnumerator ReleaseShot()
    {
        foreach (DefenderProjectile p in shotarray)
        {
            SpawnShot(p);
            yield return new WaitForSeconds(0);
        }
    }
    private void SpawnShot(DefenderProjectile p)
    {
        int bal = FindObjectOfType<Master>().BankLimit();
        int cost = p.ShotCost();
        if (cost <= bal)
        {
            FindObjectOfType<Master>().Withdrawal(cost);
            foreach(GameObject f in firePoint)
            {
             DefenderProjectile np =  Instantiate(p, f.transform.position, transform.rotation);
                np.transform.parent = projectileParent.transform;

            }  
        }
        else
        {
            GetComponent<Animator>().SetBool("Shoot", false);
        }
    }
}
