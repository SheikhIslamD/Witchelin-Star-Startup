using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnInterval = 3.5f;

    private bool firstKill = false;
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

    public GameObject slimeBox;
    public GameObject beholderBox;
    public GameObject cockBox;

    public static EnemySpawner instance;
    void Awake()
    {
        firstKill = false;
        //for making this a singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    public void KillMonsters()
    {
        Debug.Log("Main Active, destroy current");
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Monster in Monsters)
        {
            Destroy(Monster);
        }
    }
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

    public void StartSpawn()
    {
        StartCoroutine(spawnEnemy(slimeTimer, slimePrefab, slimeTransform));
        StartCoroutine(spawnEnemy(beholderTimer, beholderPrefab, beholderTransform));
        StartCoroutine(spawnEnemy(cockTimer, cockPrefab, cockTransform));

        slimeBox.SetActive(false);
        beholderBox.SetActive(false);
        cockBox.SetActive(false);
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
                    slimeBox.SetActive(true);
                }
                break;
            case "Cockatrice":
            if (!cockGate)
                {
                    cockGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(monstername);
                    cockBox.SetActive(true);
                }
                break;
            case "Beholder":
            if (!beholderGate)
                {
                    beholderGate = true;
                    AssignUnlocks.instance.AssignDishUnlocks(monstername);
                    beholderBox.SetActive(true);
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
