using System.Collections;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    AssignUnlocks au;
    GetCustomer gc;

    public Wave[] waves;
    int waveCount = 0;


    // Need to spawn a customer and have them place an order
    void Awake()
    {
        au = GetComponent<AssignUnlocks>();
        gc = GetComponent<GetCustomer>();

        waves = Resources.LoadAll<Wave>("Wave");

        Debug.Log("au: " + au + "\ngc: " + gc);
        Debug.Log("waves: " + waves.Length);
    }

    public void StartNextWave()
    {
        if (waveCount == waves.Length)
        {
            Debug.Log("Hit max wave");
            return;
        }
        Debug.Log("Spawn Wave");
        au.AssignWaveCustomerUnlocks(waves[waveCount].waveNumber);
        StartCoroutine(WaveSpawn(waves[waveCount].spawnCount));

        waveCount++; 
    }

    IEnumerator WaveSpawn(int custCount)
    {
        Debug.Log("CoRoutine Started. Will loop: " + custCount + " time(s)");
        for (int i = 0; i < custCount; i++)
        {
            gc.spawnCustomer();
            yield return new WaitForSeconds(5);
        }

    }
}
