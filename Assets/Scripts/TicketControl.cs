using UnityEngine;
using TMPro;

public class TicketControl : MonoBehaviour
{
    public int ticketNumber;
    public Sprite orderSprite;

    SpriteRenderer childSR;
    TextMeshPro childText;

    void Awake()
    {
        childSR = transform.GetComponentInChildren<SpriteRenderer>();
        childText = transform.GetComponentInChildren<TextMeshPro>();

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
