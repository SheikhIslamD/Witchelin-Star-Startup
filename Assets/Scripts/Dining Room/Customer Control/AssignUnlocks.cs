using System.Collections.Generic;
using UnityEngine;

public class AssignUnlocks : MonoBehaviour
{
    [Header("List Control")]
    public List<Customer> waveCustomers;
    public List<Protein> unlockedDishes;
    public CustomerDatabase c_Database;
    public ProteinDatabase p_Database;

    private void Start()
    {
        waveCustomers = new List<Customer>();
        unlockedDishes = new List<Protein>();
    }
    public void AssignWaveCustomerUnlocks(int wave)
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

    void AssignDishUnlocks(string protein)
    {
        switch (protein)
        {
            case "Slime": // Morning Rush
                unlockedDishes.AddRange(p_Database.slimeDishes);
                break;
            case "Cock": // Lunch Rush
                unlockedDishes.AddRange(p_Database.cockDishes);
                break;
            case "Behold": // Dinner Rush
                unlockedDishes.AddRange(p_Database.beholderDishes);
                break;
            default:
                break;
        }
    }    
}
