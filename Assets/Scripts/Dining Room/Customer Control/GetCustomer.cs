using System.Collections.Generic;
using UnityEngine;

public class GetCustomer : MonoBehaviour
{
    [Header("Customer Tracking")]
    int customerNumber = 0;
    public GameObject guestPrefab;

    [Header("Selection Tracking")]
    Customer selectedCustomer;
    Protein selectedDish;

    [Header("List Tracking")]
    AssignUnlocks au;
    DiningManager dm;

    void Start()
    {
        au = GetComponent<AssignUnlocks>();
        dm = GetComponent<DiningManager>();
    }
    void PickAssets()
    {
        // Clear previous selection;
        selectedCustomer = null;
        selectedDish = null;

        // Get random index from array
        int index = Random.Range(0, au.waveCustomers.Count);
        // Assign a Customer
        selectedCustomer = au.waveCustomers[index];
        // Manage List to avoid spawning dupe in this wave
        au.waveCustomers.RemoveAt(index);
        au.waveCustomers.TrimExcess();
        // Assign a dish
        selectedDish = au.unlockedDishes[Random.Range(0, au.unlockedDishes.Count)];
    }
    public void spawnCustomer()
    {
        // Pick assets from lists
        PickAssets();
        // Instantiate a customer GO
        GameObject guest = Instantiate(guestPrefab);
        // Get script from GO
        CustomerControl guestScript = guest.GetComponent<CustomerControl>();
        // Manage customer number
        guestScript.customerNumber = customerNumber;
        customerNumber++;
        // Assign the data to the GO
        guestScript.AssignData(selectedCustomer, selectedDish);
        // Put them in line
        dm.AddToLine(guest);
    }
    
}
