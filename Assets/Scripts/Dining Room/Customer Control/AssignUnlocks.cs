using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssignUnlocks : MonoBehaviour
{
    [Header("List Control")]
    public List<Customer> waveCustomers;
    public List<Protein> unlockedDishes;
    public CustomerDatabase c_Database;
    public ProteinDatabase p_Database;

    public Customer test;

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
        Debug.Log("Adding Customers");
        waveCustomers.AddRange(c_Database.anytimeCustomers);

        test = waveCustomers[0];
        Debug.Log("Hi I'm test: " + test);
        // Based on Time of Day, add other customers
        switch (wave)
        {
            case 0: // Morning Rush
                if (c_Database.morningCustomers.Count > 0)
                {
                    waveCustomers.AddRange(c_Database.morningCustomers);
                }                
                break;
            case 1: // Lunch Rush
                if (c_Database.lunchCustomers.Count > 0)
                {
                    waveCustomers.AddRange(c_Database.lunchCustomers);
                }
                break;
            case 2: // Dinner Rush
                if (c_Database.dinnerCustomers.Count > 0)
                {
                    waveCustomers.AddRange(c_Database.dinnerCustomers);
                }
                break;
            default:
                break;
        }
        Debug.Log("Avaliable Customer Count: " + waveCustomers.Count);
    }

    public void AssignDishUnlocks(string protein)
    {
        switch (protein)
        {
            case "Slime":
                unlockedDishes.AddRange(p_Database.slimeDishes);
                break;
            case "Cock":
                unlockedDishes.AddRange(p_Database.cockDishes);
                break;
            case "Behold":
                unlockedDishes.AddRange(p_Database.beholderDishes);
                break;
            default:
                break;
        }

        Debug.Log("Added " + protein + "Dishes. New dish list size = " +  unlockedDishes.Count);
    }    
}
