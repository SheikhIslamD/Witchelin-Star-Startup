using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [Header("Order Management")]
    public List<GameObject> tickets;
    public GameObject ticketPrefab;

    int i;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tickets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateTicket(CustomerControl guestInfo)
    {
        GameObject ticket = Instantiate(ticketPrefab);
        TicketControl tc = ticket.GetComponent<TicketControl>();

        tc.ticketNumber = guestInfo.customerNumber;
        tc.orderSprite = guestInfo.customerOrder.dishSprite;
        tc.AssignValues();
    }
}
