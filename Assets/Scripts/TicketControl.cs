using UnityEngine;
using TMPro;

public class TicketControl : MonoBehaviour
{
    public int ticketNumber;
    public Sprite orderSprite;

    GameObject childSprite;
    GameObject childNumber;

    void Start()
    {
        childSprite = transform.GetChild(0).gameObject;
        childNumber = transform.GetChild(1).gameObject;
    }

    public void AssignValues()
    {        
        childSprite.GetComponent<SpriteRenderer>().sprite = orderSprite;
        if (ticketNumber >= 9)
        {
            childNumber.GetComponent<TextMeshProUGUI>().text = ticketNumber + 1.ToString();
        }
        else
        {
            childNumber.GetComponent<TextMeshProUGUI>().text = "0" + ticketNumber + 1.ToString();
        }
    }
}
