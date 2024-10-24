using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnInterval = 3.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, spawnPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnInterval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(-5.54356146f, 3.77999997f, -7.71999979f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
