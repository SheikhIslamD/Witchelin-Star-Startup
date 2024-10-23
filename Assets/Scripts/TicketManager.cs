using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [Header("Order Management")]
    [SerializeField] GameObject[] tickets = new GameObject[10];
    [SerializeField] Transform[] spots = new Transform[10];
    [SerializeField] GameObject ticketPrefab;
        
    int ticketCount = 0;
    public void CreateTicket(CustomerControl guestInfo)
    {
        GameObject ticket = Instantiate(ticketPrefab);
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
        tickets[ticketCount - 1].transform.localScale = new Vector3(0.877617836f, 1.567307f, 0.0407048538f);
    }

    public void DestroyTicket(int ticketNumber)
    {
        if (tickets[ticketNumber] != null)
        {
            Destroy(tickets[ticketNumber]);
            tickets[ticketNumber] = null;
        }
    }
}