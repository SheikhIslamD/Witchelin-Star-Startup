using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using System.Collections;
using UnityEngine.UI;

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
    public int customersLeft;

    [Header("Canvas")]
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI guestName;
    [SerializeField] Button takeOrder;

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
    }

    void Update()
    {
        LineManager();
        CounterCanvasManager();
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

    void CounterCanvasManager()
    {
        if (counter != null)
        {
            // Enable UI
            guestName.text = counter.name;
            takeOrder.interactable = true;
            takeOrder.enabled = true;
            canvas.enabled = true;
        }
        else if(pickup != null)
        {
            guestName.text = pickup.name;
            takeOrder.interactable = false;
            takeOrder.enabled = false;
            canvas.enabled = true;
        }
        else
        {
            //Disable UI
            takeOrder.interactable = false;
            takeOrder.enabled = false;
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

        tabled++;
    }

    public void PickupOrder(int ticketNumber)
    {
        pickup = tables[ticketNumber];
        pickup.transform.position = pickupPosition.position;
        Debug.Log(pickup.name + " is picking up.");
        tables[ticketNumber] = null;

        StartCoroutine(ToPickupCounter(ticketNumber));
    }

    IEnumerator ToPickupCounter(int ticketNumber)
    {
        CustomerControl pickupScript = pickup.GetComponent<CustomerControl>();

        if (pickupScript.ReviewOrder(PlayerHands.instance.heldItem.GetComponent<Ingredient>()))
        {
            CounterManager.instance.ReviewOrder();
            yield return new WaitForSeconds(3);
            pickupScript.sr.sprite = pickupScript.customerMood[0];

            //avaliableTables.Add(takenTables[ticketNumber]);
            //takenTables.Remove(takenTables.ElementAt(ticketNumber));
            //Whatever other happy result functions;
            Destroy(TicketManager.instance.tickets.ElementAt(ticketNumber));

            tables[ticketNumber] = pickup;
            pickup = null;
            
            Destroy(tables.ElementAt(ticketNumber));

            customersLeft--;

            if (CustomerSystem.instance.everoneSpawned && DiningManager.instance.customersLeft <= 0)
            {
                CustomerSystem.instance.StartNextWave();
            }
        }
        else
        {
            CounterManager.instance.ReviewOrder();
            yield return new WaitForSeconds(3);
            pickupScript.sr.sprite = pickupScript.customerMood[0];


            tables[ticketNumber] = pickup;
            tables[ticketNumber].transform.position = takenTables.ElementAt(ticketNumber).position;
            pickup = null;
        }

        Destroy(PlayerHands.instance.heldItem);
        PlayerHands.instance.PutDown();
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

        customersLeft--;
        Debug.Log("Oh no! someone left! current lives: " + CustomerSystem.instance.playerReviewHealth);
    }
}