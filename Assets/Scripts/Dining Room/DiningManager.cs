using UnityEngine;
using System.Collections.Generic;
using TMPro;

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
    [SerializeField] Transform counterPosition;
    [SerializeField] Transform pickupPosition;

    int waiting = 0;
    int lineOrder = 0;

    [Header("Get Scripts")]
    [SerializeField] CustomerSystem cs;
    [SerializeField] AssignUnlocks au;
    [SerializeField]  GetCustomer gc;

    [Header("Canvas")]
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI guestName;

    //Managae Locations
    //Counter Controlls
    //Ticket Management
    void Start()
    {
        line = new LinkedList<GameObject>();

        // *NEEDS TO BE ADDED* Set variable to begin wave spawner
        au.AssignDishUnlocks("Cock");
        cs.StartNextWave();
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
        int i = Random.Range(0, tablePositions.Length);

        if (tables[i] == null)
        {
            tables[i] = counter;
            tables[i].transform.position = tablePositions[i].position;
            counter = null;
        }
        else
        {
            SitDown();
        }
    }

    public void PickupOrder(int ticketNumber)
    {
        pickup = tables[ticketNumber];

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