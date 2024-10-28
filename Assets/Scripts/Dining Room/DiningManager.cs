using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class DiningManager : MonoBehaviour
{
    [Header("Line Management")]
    LinkedList<GameObject> line;
    public GameObject counter;
    public GameObject pickup;
    GameObject[] tables = new GameObject[10];

    [SerializeField] Transform[] linePositions = new Transform[10];
    [SerializeField] Transform[] tablePositions = new Transform[10];
    List<Transform> avaliableTables = new List<Transform>();
    List<Transform> takenTables = new List<Transform>();
    [SerializeField] Transform counterPosition;
    [SerializeField] Transform pickupPosition;

    int tabled = 0;
    int waiting = 0;
    int lineOrder = 0;

    [Header("Canvas")]
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI guestName;

    //Managae Locations
    //Counter Controlls
    //Ticket Management

    public static DiningManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        line = new LinkedList<GameObject>();
        avaliableTables.AddRange(tablePositions);

        // *NEEDS TO BE ADDED* Set variable to begin wave spawner
        AssignUnlocks.instance.AssignDishUnlocks("Cock");
        CustomerSystem.instance.StartNextWave();
    }

    void Update()
    {
        LineManager();
        CounterManager();
    }

    public void AddToLine(GameObject guest)
    {
        // Take guest object and place it in linked list
        line.AddFirst(guest);
        guest.transform.position = linePositions[waiting].position;
        waiting++;
        lineOrder++;
    }
    void LineManager()
    {
        if (counter == null && line.Last != null)
        {
            // Move guest waiting to counter in world space
            line.Last.Value.transform.position = counterPosition.position;
            // Make them a counter gameobject
            counter = line.Last.Value;
            // Remove them from the line
            line.RemoveLast();
            waiting--;
            // Move up the other guest
            MoveGuest();
        }
    }

    void MoveGuest()
    {
        foreach(GameObject guest in line)
        {
            guest.transform.position = linePositions[lineOrder - 1].position;
            lineOrder--;
        }

        lineOrder = waiting;
    }

    void CounterManager()
    {
        if (counter != null)
        {
            // Enable UI
            guestName.text = counter.name;
            canvas.enabled = true;
        }
        else
        {
            //Disable UI
            canvas.enabled = false;
        }
    }

    public void SitDown()
    {
        tables[tabled] = counter;
        counter = null;

        int i = Random.Range(0, avaliableTables.Count);
        tables[tabled].transform.position = avaliableTables[i].transform.position;
        takenTables.Add(avaliableTables[i]);
        avaliableTables.RemoveAt(i);

    }

    public void PickupOrder(int ticketNumber)
    {
        pickup = tables[ticketNumber];
        tables[ticketNumber] = null;

        CustomerControl pickupScript = pickup.GetComponent<CustomerControl>();
        // WILL NEED TO CONNECT TO HAND
        // HAND MUST HOLD PLATED OBJECT
        if (pickupScript.ReviewOrder(PlayerHands.instance.heldItem.GetComponent<Ingredient>()))
        {
            avaliableTables.Add(takenTables.ElementAt(ticketNumber));
            takenTables.RemoveAt(ticketNumber);
            //Whatever other happpy result functions;
            pickup = null;
        }
        else
        {
            tables[ticketNumber] = pickup;
            pickup = null;
        }
    }

    public void GuestLeaves(GameObject guestName)
    {
        if (line.Contains(guestName))
        {
            line.Remove(guestName);
        }
        else
        {
            for (int i = 0; i < tables.Length; i++)
            {
                if (tables[i] == guestName)
                {
                    tables[i] = null;
                    break;
                }
            }
        }
    }
}