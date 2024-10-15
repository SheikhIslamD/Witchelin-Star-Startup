using System.Collections;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    AssignUnlocks au;
    GetCustomer gc;

    public Wave[] waves;
    int waveCount = 0;


    // Need to spawn a customer and have them place an order
    void Start()
    {
        au = GetComponent<AssignUnlocks>();
        gc = GetComponent<GetCustomer>();

        waves = Resources.LoadAll<Wave>("Wave");
        //Run a wave spawner coroutine
        //Call Spawn
        //Function on interaction 
    }

    void StartNextWave()
    {
        if (waveCount == waves.Length)
        {
            Debug.Log("Hit max wave");
            return;
        }
        au.AssignWaveCustomerUnlocks(waves[waveCount].waveNumber);
        StartCoroutine(WaveSpawn(waves[waveCount].spawnCount));

        waveCount++; 
    }

    IEnumerator WaveSpawn(int custCount)
    {
        for (int i = 0; i < custCount; i++)
        {
            gc.spawnCustomer();
            yield return new WaitForSeconds(5);
        }

    }
}
