using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    [Header("Customer Identifiers")]
    public int customerNumber;
    public string customerName;
    [Space(10)]

    [Header("Customer Order")]
    public Protein customerOrder;
    [Space(10)]


    [Header("Waiting Information")]
    float patienceMax;
    float patienceRate;

    // Give this specific Gameobject data from the selected Scriptable Object
    public void AssignData(Customer guest, Protein dish)
    {
        // Give this GO a Name
        customerName = guest.customerName;
        // Set this GO patience values
        patienceMax = guest.patienceMax;
        patienceRate = guest.patienceRate;

        // Make Sure this guy can be seen
        GetComponent<SpriteRenderer>().sprite = guest.customerSprite;

        // Assign this GO a name
        customerOrder = dish;
        
    }

    // When Interacted with, provide the Player with an order
    public void PlaceOrder()
    {
        Debug.Log("Hi, I'd like to order " + customerOrder);
    }

    // When Order is done, Review the Order
    public void ReviewOrder(Ingredient given)
    {
        if (given != null)
        {
            if(given.dishName != customerOrder.dishName)
            {
                //
                Debug.Log("You gave me the wrong dish!");
                return;
            }
            
            switch (given.cookState)
            {
                case 0:
                    Debug.Log("This is under cooked!");
                    break;
                case 1:
                    Debug.Log("This is Perfect!");
                    break;
                case 2:
                    Debug.Log("This was cooked way too long!");
                    break;
                default:
                    Debug.Log("State is inaccurate");
                    break;
            }

        }

    }
}
