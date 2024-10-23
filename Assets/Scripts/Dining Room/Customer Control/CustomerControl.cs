using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    [Header("Customer Identifiers")]
    public int customerNumber;
    [Space(10)]

    [Header("Customer Order")]
    public Protein customerOrder;
    [Space(10)]


    [Header("Waiting Information")]
    public float patienceMax;
    public float patienceRate;
    public float patienceCurrent;
    bool counter = false;

    [Header("Script Managers")]
    DiningManager dm;
    TicketManager tm;

    void Start()
    {
        patienceCurrent = patienceMax;
        dm = GameObject.FindGameObjectWithTag("DiningRoom").GetComponent<DiningManager>();
        tm = GameObject.FindGameObjectWithTag("TicketManager").GetComponent<TicketManager>(); 
    }

    void Update()
    {
        if (dm.counter == gameObject)
        {
            if (!counter)
            {
                counter = true;
                patienceCurrent = patienceMax;
            }            
        }
        else
        {
            PatienceManager();
        }

    }

    void PatienceManager()
    {        
        patienceCurrent -= patienceRate * Time.deltaTime;

        if (patienceCurrent <= 0)
        {
            dm.GuestLeaves(gameObject);
            tm.DestroyTicket(customerNumber);

            // Make this an animation
            Destroy(gameObject);
        }
    }

    void ChunkPatience()
    {
        patienceCurrent -= patienceMax / 5;
    }

    // Give this specific Gameobject data from the selected Scriptable Object
    public void AssignData(Customer guest, Protein dish)
    {
        // Set this GO patience values
        patienceMax = guest.patienceMax;
        patienceRate = guest.patienceRate;

        // Make Sure this guy can be seen
        GetComponent<SpriteRenderer>().sprite = guest.customerSprite;

        // Assign this GO a name
        customerOrder = dish;        
    }

    // When Interacted with, provide the Player with an order
    public string PlaceOrder()
    {
        Debug.Log("Hi, I'd like to order - " + customerOrder.dishName);
        return("Hi, I'd like to order - " + customerOrder.dishName);
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
                ChunkPatience();
                return;
            }
            
            switch (given.cookState)
            {
                case 0:
                    Debug.Log("This is under cooked!");
                    ChunkPatience();
                    break;
                case 1:
                    Debug.Log("This is Perfect!");
                    break;
                case 2:
                    Debug.Log("This was cooked way too long!");
                    ChunkPatience();
                    break;
                default:
                    Debug.Log("State is inaccurate");
                    break;
            }

        }

    }
}
