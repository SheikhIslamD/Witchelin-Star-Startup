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

    public static GetCustomer instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void PickAssets()
    {
        // Clear previous selection;
        selectedCustomer = null;
        selectedDish = null;

        // Get random index from array
        int index = Random.Range(0, AssignUnlocks.instance.waveCustomers.Count);
        Debug.Log("Selected index: " + index);
        // Assign a Customer
        selectedCustomer = AssignUnlocks.instance.waveCustomers[index];
        Debug.Log("Selected customer was: " + selectedCustomer);
        // Manage List to avoid spawning dupe in this wave
        AssignUnlocks.instance.waveCustomers.RemoveAt(index);
        AssignUnlocks.instance.waveCustomers.TrimExcess();
        Debug.Log("Adjusted length of possible customers: " +  AssignUnlocks.instance.waveCustomers.Count);
        // Assign a dish
        selectedDish = AssignUnlocks.instance.unlockedDishes[Random.Range(0, AssignUnlocks.instance.unlockedDishes.Count)];
    }
    public void spawnCustomer()
    {
        Debug.Log("Call Spawner");
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
        guest.name = selectedCustomer.name;
        // Put them in line
        DiningManager.instance.AddToLine(guest);
    }
    
}
