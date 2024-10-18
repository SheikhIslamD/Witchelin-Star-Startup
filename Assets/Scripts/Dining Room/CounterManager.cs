using UnityEngine;
using TMPro;
using System.Collections;

public class CounterManager : MonoBehaviour
{
    TicketManager tm;
    DiningManager dm;

    public GameObject orderBox;
    public TextMeshProUGUI orderDescription;

    void Start()
    {
        tm = GameObject.FindWithTag("TicketManager").GetComponent<TicketManager>();
        dm = GameObject.FindWithTag("DiningRoom").GetComponent<DiningManager>();
    }
    public void TakeOrder()
    {
        orderBox.SetActive(true);
        CustomerControl cc = dm.counter.GetComponent<CustomerControl>();
        orderDescription.text = cc.PlaceOrder();

        tm.CreateTicket(cc);

        StartCoroutine(TakeASeat());
    }

    IEnumerator TakeASeat()
    {
        yield return new WaitForSeconds(3f);
        dm.SitDown();
        orderBox.SetActive(false);
    }
}
