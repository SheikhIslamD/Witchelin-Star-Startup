using UnityEngine;
using UnityEngine.UI;

public class PlayerHands : MonoBehaviour
{
    //makin this a singleton so any other script can interact with this easily
    public static PlayerHands instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [Header("")]
    public bool handsFull; //if anything is held already
    public Image handsImage; //the UI image of the hand
    public Sprite[] handSprites; //placeholder 2 sprite setup rn
    public GameObject handHoldTransform; //the transform for where held items should show up
    public GameObject heldItem; //what is held in the hands

    private void Start()
    {
        handsFull = false;
        handsImage.sprite = handSprites[0];
        heldItem = null;
    }

    public void PickUp(GameObject item)
    {
        if (!handsFull) 
        {
            //reparent item and move it to be in the hand
            //also assign it to the heldItem variable for easy referencing elsewhere
            heldItem = item;
            item.transform.SetParent(handHoldTransform.transform, true);
            item.transform.position = handHoldTransform.transform.position;

            //set sprite to gripping hand, set holding bool to true
            handsImage.sprite = handSprites[1];
            handsFull = true;
            Debug.Log("Picked up " + heldItem.name);
        }
    }

    public void PutDown()
    {
        if (handsFull) 
        {
            //clear held item, switch to palm hand, holding bool false
            heldItem = null;
            handsImage.sprite = handSprites[0];
            handsFull = false;
            Debug.Log("Item put down");
        }
    }
}
