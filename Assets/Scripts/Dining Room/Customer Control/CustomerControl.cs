using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    [Header("Customer Identifiers")]
    public int customerNumber;
    public Sprite customerSprite;
    public Sprite[] customerMood = new Sprite[3]; 
    [Space(10)]

    [Header("Customer Order")]
    public Protein customerOrder;
    public string customerReview;
    [Space(10)]


    [Header("Waiting Information")]
    public float patienceMax;
    public float patienceRate;
    public float patienceCurrent;
    bool counter = false;

    [Header("Script Managers")]
    //DiningManager dm;
    TicketManager tm;

    void Start()
    {
        patienceCurrent = patienceMax;
        tm = GameObject.FindGameObjectWithTag("TicketManager").GetComponent<TicketManager>(); 
    }

    void Update()
    {
        if (DiningManager.instance.counter == gameObject)
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
        if (patienceCurrent > patienceMax / 2)
        {
            customerSprite = customerMood[0];
        }
        else if (patienceCurrent <= patienceMax / 2)
        {
            customerSprite = customerMood[1];

            if (patienceMax <= patienceMax / 4)
            {
                customerSprite = customerMood[2];

                if (patienceCurrent <= 0)
                {
                    if (gameObject.name == "The King")
                    {
                        //End Game
                        Phases.instance.FinishGame("lose");
                    }

                    CustomerSystem.instance.playerReviewHealth--;
                    DiningManager.instance.GuestLeaves(gameObject);
                    tm.DestroyTicket(customerNumber);

                    // Make this an animation
                    Destroy(gameObject);
                }
            }
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
    public bool ReviewOrder(Ingredient given)
    {
        if (given != null)
        {
            if(given.dishName != customerOrder.dishName)
            {
                //
                Debug.Log("You gave me the wrong dish!");
                customerReview = "You gave me the wrong dish!";
                ChunkPatience();
                return false;
            }
            
            switch (given.cookState)
            {
                case 0:
                    Debug.Log("This is under cooked!");
                    customerReview = "This is under cooked!";
                    ChunkPatience();
                    return false;
                case 1:
                    Debug.Log("This is Perfect!");
                    customerReview = "This is Perfect!";
                    // IF king win
                    if (gameObject.name == "The King")
                    {
                        //End Game
                        Phases.instance.FinishGame("win");
                    }

                    return true;
                case 2:
                    Debug.Log("This was cooked way too long!");
                    customerReview = "This was cooked way too long!";
                    ChunkPatience();
                    return false;
                default:
                    Debug.Log("State is inaccurate");
                    break;
            }

        }
        return false;
    }

    public string VoiceReview()
    {

        Debug.Log("" + customerReview);
        return ("" + customerReview);
    }
}
