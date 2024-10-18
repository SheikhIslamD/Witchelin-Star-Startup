using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CounterManager : MonoBehaviour
{
    TicketManager tm;
    DiningManager dm;


    public TextMeshProUGUI guestName;
    public TextMeshProUGUI orderDescription;

    void Start()
    {
        tm = GameObject.FindWithTag("TicketManager").GetComponent<TicketManager>();
        dm = GameObject.FindWithTag("DiningRoom").GetComponent<DiningManager>();
    }
    public void TakeOrder()
    {
        CustomerControl cc = dm.counter.GetComponent<CustomerControl>();
        orderDescription.text = cc.PlaceOrder();

        tm.CreateTicket(cc);
    }
}
