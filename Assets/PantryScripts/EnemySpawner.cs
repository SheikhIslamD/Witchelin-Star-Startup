using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnInterval = 3.5f;

    private bool firstKill = false;
    private bool slimeGate, cockGate, beholderGate = false;
        
    public void SpawnEnemyCountdownBegin()
    {
        StartCoroutine(spawnEnemy(spawnInterval, spawnPrefab));
    }

    public void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, spawnPrefab));
    }

    //Enemy Spawn Based on Location and Time
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnInterval);
        GameObject newEnemy = Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);        
    }

    public void CheckSpawns()
    {
        if (!firstKill)
        {
            CustomerSystem.instance.StartNextWave();            
        }

        switch(spawnPrefab.name)
        {
            case "Slime":
                if (!slimeGate)
                {
                    slimeGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(spawnPrefab.name);
                }
                break;
            case "Cockatrice":
            if (!cockGate)
                {
                    cockGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(spawnPrefab.name);
                }
                break;
            case "Beholder":
            if (!beholderGate)
                {
                    beholderGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(spawnPrefab.name);
                }
                break;
        }
    }
}
