using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TicketControl : MonoBehaviour
{
    /* I made it a canvas so it could move between rooms
     * Now its hard to track.
     * I need to track a few things:
     * 
     * For the buttons:
     * I need to track when a ticket is present to enable its functionality
     * I also need to track the ticket
     * 
     * For The kithen dining connection
     * I need to be able to plate and present that plate to customers
     * Probably need sheikh for that
     */


    /* Buttons are not enabled unless something is plated.         ||Kitchen Plating Script
     * When plated and in dining, buttons are active               ||Make Buttons part of Dining Canvas?
     * On button press, present to that customer                   ||Dining Manager
     * Button should remain disabled unless a ticket is present    ||Connect to this?
     */

    public int ticketNumber;
    public Sprite orderSprite;

    Image childSR;
    TextMeshProUGUI childText;

    Button button;
    [SerializeField] DiningManager dm;

    public static TicketControl instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        childSR = transform.GetChild(0).GetComponentInChildren<Image>();
        childText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();

        Debug.Log("Ticket Sprite object: " + childSR + "\nTicket Number object: " + childText);
        button = transform.GetChild(2).GetComponentInChildren<Button>();
        button.interactable = false;
        StartCoroutine(WaitToMove());
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

    public void PresentToGuest()
    {
        dm.PickupOrder(ticketNumber);
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(3);
        button.interactable = true;
    }

    void OnDestroy()
    {
       //Play burnup animation
    }
}