using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
   
    public float speed;
    GameObject currentTarget;
    
    private void Awake()
    {
        FindObjectOfType<MasterScript>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        try
        {
            MasterScript MS = FindObjectOfType<MasterScript>();
            if (MS != null)
            {
                MS.AttackerKilled();
            }
        }
        catch { return; }

 
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed * Time.deltaTime);
        int xpos = Mathf.RoundToInt(gameObject.transform.position.x);
        if (xpos == 3)
        {
            speed = 0;
            try
            {
                GetComponent<Animator>().SetBool("Idle", true);
            }
            catch
            {
                return;
            }
        }
        UpdateAnimationStateControl();
    }

    private void UpdateAnimationStateControl()
    {
        //if there is no target stop attacking
        if (!currentTarget&&!gameObject.name.Contains("VikingShip"))
        {
            if (!gameObject.name.Contains("GunPirateShip"))
            {
                GetComponent<Animator>().SetBool("Shoot", false);
            }
        }
       
    }
  

    public void Attack(GameObject target)
    {
        if(!gameObject.name.Contains("VikingShip"))
        {
            if (!gameObject.name.Contains("GunPirateShip"))
            {
                GetComponent<Animator>().SetBool("Shoot", true);
                currentTarget = target;
            }

        }
      
       
    }
    public void Speed(float travel)
    {
        speed = travel;
    }
}
