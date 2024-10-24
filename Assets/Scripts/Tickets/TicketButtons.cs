using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TicketButtons : MonoBehaviour
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

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        StartCoroutine(WaitToMove());
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(3);
        button.interactable = true;
    }

}
