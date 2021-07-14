using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;

    [SerializeField] int maxYpos =6;
    [SerializeField] int minYpos = 0;
    [SerializeField] float maxSpawnDelay =6f;
    [SerializeField] float minSpawnDelay =2f;
    [SerializeField] Attacker[] attackerPrefab;


    // Start is called before the first frame update
    IEnumerator Start()
    {
       while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Vector2 nv = new Vector2(10, (Random.Range(minYpos, maxYpos)));
        var AttackerIndex = Random.Range(0, attackerPrefab.Length);
        _ = Instantiate(attackerPrefab[AttackerIndex], nv, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
