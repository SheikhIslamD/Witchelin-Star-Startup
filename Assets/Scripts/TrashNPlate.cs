using UnityEngine;

public class TrashNPlate : MonoBehaviour
{
    public GameObject platedTransform;
    public GameObject trashTransform;
    public GameObject platedfood;
    public GameObject Pickup;

    private void Start()
    {
        platedfood = null;
        Pickup.SetActive(false);
    }

    public void Plating()
    {
        platedfood = PlayerHands.instance.heldItem;
        //update ingredient to reflect plated appearance according to current station's cookMethod 
        platedfood.GetComponent<Ingredient>().PlatingUpdate();
        PlayerHands.instance.PutDown();
        platedfood.transform.SetParent(platedTransform.transform, true);
        platedfood.transform.position = platedTransform.transform.position;
        Pickup.SetActive(true);
    }

    public void PickupDish()
    {
        if (!PlayerHands.instance.handsFull)
        {
            PlayerHands.instance.PickUp(platedfood);
            platedfood = null;
            Pickup.SetActive(false);
        }
    }

    public void Trashcan()
    {
        //Destroy(PlayerHands.instance.heldItem);
        //PlayerHands.instance.PutDown();

        //trying just placing them in scene with randomness to make a pile
        GameObject trashedfood = PlayerHands.instance.heldItem;
        PlayerHands.instance.PutDown();
        trashedfood.transform.SetParent(trashTransform.transform, true);
        float random = Random.Range(-10, 10);
        trashedfood.transform.position = new Vector3 (trashTransform.transform.position.x + random, trashTransform.transform.position.y + random, trashTransform.transform.position.z + random);
        trashedfood.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);

        Debug.Log("Item trashed");
    }

}
