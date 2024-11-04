using System.Collections;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    public Wave[] waves = new Wave[2];
    public int waveCount = 0;

    public static CustomerSystem instance;
    // Need to spawn a customer and have them place an order
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        waves = Resources.LoadAll<Wave>("Wave");
        Debug.Log(waves.Length + " Waves.");
    }

    public void StartNextWave()
    {
        if (waveCount == waves.Length)
        {
            Debug.Log("Hit max wave");
            return;
        }
        Debug.Log("Spawn Wave");
        AssignUnlocks.instance.AssignWaveCustomerUnlocks(waves[waveCount].waveNumber);
        StartCoroutine(WaveSpawn(waves[waveCount].spawnCount));

        waveCount++; 
    }

    IEnumerator WaveSpawn(int custCount)
    {
        Debug.Log("CoRoutine Started. Will loop: " + custCount + " time(s)");
        for (int i = 0; i < custCount; i++)
        {
            GetCustomer.instance.spawnCustomer();
            yield return new WaitForSeconds(10);
        }

    }
}
