using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    [Header("Customer Identifiers")]
    public int customerNumber;
    public string customerName;
    [Space(10)]

    [Header("Customer Order")]
    Dish customerOrder;
    [Space(10)]


    [Header("Waiting Information")]
    float patienceMax;
    float patienceRate;

    public void AssignData(Customer guest, Dish dish)
    {
        customerName = guest.customerName;
        patienceMax = guest.patienceMax;
        patienceRate = guest.patienceRate;

        GetComponent<SpriteRenderer>().sprite = guest.customerSprite;

        customerOrder = dish;
    }
}
