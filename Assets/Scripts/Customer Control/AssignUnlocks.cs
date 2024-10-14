using System.Collections.Generic;
using UnityEngine;

public class AssignUnlocks : MonoBehaviour
{
    [Header("List Control")]
    List<Customer> waveCustomers;
    public CustomerDatabase c_Database;
    public DishDatabase d_Database;

    private void Start()
    {
        waveCustomers = new List<Customer>();
    }
    void AssignWaveCustomerUnlocks(int wave)
    {
        // Empty any Customers in List at start of wave
        waveCustomers.Clear();
        // Add the Anytime Customers
        waveCustomers.AddRange(c_Database.anytimeCustomers);
        // Based on Time of Day, add other customers
        switch (wave)
        {
            case 0: // Morning Rush
                waveCustomers.AddRange(c_Database.morningCustomers);
                break;
            case 1: // Lunch Rush
                waveCustomers.AddRange(c_Database.lunchCustomers);
                break;
            case 2: // Dinner Rush
                waveCustomers.AddRange(c_Database.dinnerCustomers);
                break;
            default:
                break;
        }
    }

    void PickAssets()
    {
        // Get random index from array
        int index = Random.Range(0,waveCustomers.Count -1);
        // Instantiate the customer model 
        Customer customer = waveCustomers[index];
        waveCustomers.RemoveAt(index);
        waveCustomers.TrimExcess();
        Dish dish = d_Database.unlockedDishes[Random.Range(0, d_Database.unlockedDishes.Count - 1)];
    }
}
