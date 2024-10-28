using UnityEngine;
using TMPro;
using System.Collections;

public class CounterManager : MonoBehaviour
{
    [Header("Script Gets")]
    [SerializeField] TicketManager tm;
    [SerializeField] DiningManager dm;

    [Header("Canvas Gets")]
    [SerializeField] GameObject orderBox;
    [SerializeField] TextMeshProUGUI orderDescription;

    public static CounterManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
        tm.TicketToLine();
        orderBox.SetActive(false);
    }
}