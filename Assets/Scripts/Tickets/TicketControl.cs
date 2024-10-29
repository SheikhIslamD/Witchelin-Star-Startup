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
    void Awake()
    {
        childSR = transform.GetChild(0).GetComponentInChildren<Image>();
        childText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();

        Debug.Log("Ticket Sprite object: " + childSR + "\nTicket Number object: " + childText);
        button = transform.GetChild(2).GetComponentInChildren<Button>();
        button.interactable = false;
    }

    private void Update()
    {
        if (Cameras.dining)
        {
            ToggleButton();
        }
    }
    public void ToggleButton()
    {
        if (Cameras.dining && PlayerHands.instance.heldItem.GetComponent<Ingredient>().isPlated)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
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
        DiningManager.instance.PickupOrder(ticketNumber);
    }

    void OnDestroy()
    {
       //Play burnup animation
    }
}