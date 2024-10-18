using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DiningManager : MonoBehaviour
{
    [Header("Line Management")]
    LinkedList<GameObject> line;
    public GameObject counter;
    GameObject[] tables = new GameObject[10];

    public Transform[] linePositions = new Transform[10];
    public Transform[] tablePositions = new Transform[10];
    public Transform counterPosition;

    int waiting = 0;
    int lineOrder = 0;
    [Space(10)]

    [Header("Get Scripts")]
    CustomerSystem cs;
    AssignUnlocks au;
    GetCustomer gc;

    [Header("Canvas")]
    public Canvas canvas;
    public TextMeshProUGUI guestName;

    //Managae Locations
    //Counter Controlls
    //Ticket Management
    void Start()
    {
        cs = GetComponent<CustomerSystem>();
        au = GetComponent<AssignUnlocks>();
        gc = GetComponent<GetCustomer>();

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
        if (line.Last != null)
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
}
