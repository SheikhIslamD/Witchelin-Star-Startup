using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TicketManager : MonoBehaviour
{
    [Header("Order Management")]
    public GameObject[] tickets = new GameObject[10];
    [SerializeField] Transform[] spots = new Transform[10];
    [SerializeField] GameObject ticketPrefab;

    [Header("Button Management")]
        
    int ticketCount = 0;

    public static TicketManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CreateTicket(CustomerControl guestInfo)
    {
        GameObject ticket = Instantiate(ticketPrefab, GameObject.FindGameObjectWithTag("TicketCanvas").transform);
        TicketControl tc = ticket.GetComponent<TicketControl>();        

        tc.ticketNumber = guestInfo.customerNumber;
        tc.orderSprite = guestInfo.customerOrder.dishSprite;
        tc.AssignValues();
        ticket.name = "" + tc.ticketNumber;

        tickets[ticketCount] = ticket;
        ticketCount++;
    }

    public void TicketToLine()
    {
        tickets[ticketCount - 1].transform.position = spots[ticketCount - 1].position;
        tickets[ticketCount - 1].transform.SetAsFirstSibling();
        tickets[ticketCount - 1].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void DestroyTicket(int ticketNumber)
    {
        if (tickets[ticketNumber] != null)
        {
            Destroy(tickets.ElementAt(ticketNumber));
            tickets[ticketNumber] = null;
        }
    }
}