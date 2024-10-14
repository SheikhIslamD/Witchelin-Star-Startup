using System.Collections.Generic;
using UnityEngine;

public class GetCustomer : MonoBehaviour
{
    [Header("Customer Tracking")]
    int customerNumber = 0;
    GameObject guest;

    [Header("List Tracking")]
    public AssignUnlocks au;

    void Start()
    {
        au = GameObject.FindGameObjectWithTag("Player").GetComponent<AssignUnlocks>();
    }
    void PickAssets()
    {
        // Get random index from array
        int index = Random.Range(0, au.waveCustomers.Count - 1);
        // Instantiate the customer model 
        Customer customer = au.waveCustomers[index];
        au.waveCustomers.RemoveAt(index);
        au.waveCustomers.TrimExcess();
        Dish dish = au.unlockedDishes[Random.Range(0, au.unlockedDishes.Count - 1)];
    }
    public void spawnCustomer(Customer customer, Dish dish)
    {
        guest = Instantiate(guest);
        CustomerControl guestScript = guest.GetComponent<CustomerControl>();
        guestScript.customerNumber = customerNumber;
        customerNumber++;
        guestScript.AssignData(customer, dish);
    }
    
}
