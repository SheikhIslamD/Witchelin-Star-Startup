using UnityEngine;
using TMPro;
using System.Collections;

public class CounterManager : MonoBehaviour
{
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
        CustomerControl cc = DiningManager.instance.counter.GetComponent<CustomerControl>();
        orderDescription.text = cc.PlaceOrder();

        TicketManager.instance.CreateTicket(cc);

        StartCoroutine(TakeASeat());
    }

    IEnumerator TakeASeat()
    {
        yield return new WaitForSeconds(3f);
        DiningManager.instance.SitDown();
        TicketManager.instance.TicketToLine();
        orderBox.SetActive(false);
    }
}