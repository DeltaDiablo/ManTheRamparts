using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerProjectile : MonoBehaviour
{
    [SerializeField] float speed = 20;
    [SerializeField] float damage = 10;
    public float volume;
    private void Awake()
    {
        damage = damage * PlayerPrefsController.GetDifficulty();
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GetComponent<AudioSource>().volume = PlayerPrefsController.GetSFXVolume();
        }
        catch { return; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>())
        {
            //reduce health of attackers health in their health Script
            var healthcontrol = collision.GetComponent<Health>();
            if (healthcontrol)
            {
                //get the health script of the collided item
                collision.GetComponent<Health>().DealDamage(damage);

                Destroy(gameObject);



            }
        }

    }
}
