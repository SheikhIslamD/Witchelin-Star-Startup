using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicketControl : MonoBehaviour
{
    public int ticketNumber;
    public Sprite orderSprite;

    Image childSR;
    TextMeshProUGUI childText;

    void Awake()
    {
        childSR = transform.GetChild(0).GetComponentInChildren<Image>();
        childText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();

        Debug.Log("Ticket Sprite object: " + childSR + "\nTicket Number object: " + childText);
    }

    public void AssignValues()
    {        
        childSR.sprite = orderSprite;

        if (ticketNumber >= 9)
        {
            childText.text = (ticketNumber + 1).ToString();
        }
        else
        {
            childText.text = "0" + (ticketNumber + 1).ToString();
        }
    }

    void OnDestroy()
    {
       //Play burnup animation
    }
}
