using System.Collections.Generic;
using UnityEngine;

public class GetCustomer : MonoBehaviour
{
    [Header("Customer Tracking")]
    int customerNumber = 0;
    GameObject guest;

    public void spawnCustomer(Customer customer, Dish dish)
    {
        guest = Instantiate(guest);
        CustomerControl guestScript = guest.GetComponent<CustomerControl>();
        guestScript.customerNumber = customerNumber;
        customerNumber++;
        guestScript.AssignData(customer, dish);
    }
    
}
