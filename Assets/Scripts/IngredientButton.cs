using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    //listing all ingredients as an item array for now, assign these in inspector for now
    [Header("Assign these in inspector for now")]
    public GameObject[] ingredientOptions;
    public GameObject ingredientPrefab;
    public Protein[] ingredients;
    //Assign a different ingredient's number to each button
    [Header("Assign on each button uniquely")]
    public int ingredientNumber;

    // Update is called once per frame
    public void GrabIngredient(int ingredientNumber)
    {
        if (!PlayerHands.instance.handsFull)
        {
            //spawns ingredient prefab, assigns it the proper protein of the box, and puts it in player's hands 
            GameObject item = Instantiate(ingredientPrefab);
            item.GetComponent<Ingredient>().protein = ingredients[ingredientNumber];
            //run an Ingredient.ingredientUpdate() here if the protein values dont assign on awake
            PlayerHands.instance.PickUp(item);
            PlayerHands.instance.handsFull = true;
            
            Debug.Log("Grabbed this ingredient: " + item.name);
        }
        else
        {
            ReturnIngredient();
        }
    }

    public void ReturnIngredient()
    {
        //this looks long but it's basically comparing the name of the ingredient in the player's hand to see if it matches this
        //has to do a getcomponent on the Ingredient script on both objects and read the IngredientName on it to compare with
        if (PlayerHands.instance.heldItem.GetComponent<Ingredient>().protein == ingredients[ingredientNumber] && PlayerHands.instance.heldItem.GetComponent<Ingredient>().cookState == 0)
        {
            //need to delete the item and then clear the related variables by using the PutDown function
            Destroy(PlayerHands.instance.heldItem);
            PlayerHands.instance.PutDown();

            Debug.Log("Ingredient put back");
        }
        else
        {
            Debug.Log("Can't do that! Put down the " + PlayerHands.instance.heldItem.name + " first!");
        }
    }
}
