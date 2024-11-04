using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnInterval = 3.5f;

    private static bool firstKill = false;
    private bool slimeGate, cockGate, beholderGate = false;

    public float slimeTimer;
    public float beholderTimer;
    public float cockTimer;

    public GameObject slimePrefab;
    public GameObject beholderPrefab;
    public GameObject cockPrefab;

    public Transform slimeTransform;
    public Transform beholderTransform;
    public Transform cockTransform;
        
    public void SpawnEnemyCountdownBegin(string monster)
    {
        switch (monster)
        {
            case "Slime":
                StartCoroutine(spawnEnemy(slimeTimer, slimePrefab, slimeTransform));
                break;
            case "Beholder":
                StartCoroutine(spawnEnemy(beholderTimer, beholderPrefab, beholderTransform));
                break;
            case "Cockatrice":
                StartCoroutine(spawnEnemy(cockTimer, cockPrefab, cockTransform));
                break;
        }
    }

    public void Start()
    {
        StartCoroutine(spawnEnemy(slimeTimer, slimePrefab, slimeTransform));
        StartCoroutine(spawnEnemy(beholderTimer, beholderPrefab, beholderTransform));
        StartCoroutine(spawnEnemy(cockTimer, cockPrefab, cockTransform));
    }

    //Enemy Spawn Based on Location and Time
    private IEnumerator spawnEnemy(float interval, GameObject enemy, Transform transform)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);        
    }

    public void CheckSpawns(string monstername)
    {     

        switch(monstername)
        {
            case "Slime":
                if (!slimeGate)
                {
                    slimeGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(monstername);
                }
                break;
            case "Cockatrice":
            if (!cockGate)
                {
                    cockGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(monstername);
                }
                break;
            case "Beholder":
            if (!beholderGate)
                {
                    beholderGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(monstername);
                }
                break;
        }

        if (!firstKill)
        {
            firstKill = true;
            CustomerSystem.instance.StartNextWave();            
        }
    }
}
