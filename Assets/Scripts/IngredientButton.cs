using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    //should this be handsFull or holdingIngredient?
    public bool holdingThisIngredient;
    public string whichIngredient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GrabIngredient()
    {
        if (!Cooking.instance.handsFull)
        {
            if (!holdingThisIngredient)
            {
                Cooking.instance.handsImage.color = Color.cyan;
                Cooking.instance.handsHolding = whichIngredient;
                Cooking.instance.handsFull = true;
                holdingThisIngredient = true;

                Debug.Log("Grabbed this ingredient: " + whichIngredient);
            }
            else
            {
                Debug.Log("Already holding something: " + Cooking.instance.handsHolding);
            }
        }
        else
        {
            if (Cooking.instance.handsHolding == whichIngredient)
            {
                Cooking.instance.handsImage.color = Color.clear;
                Cooking.instance.handsHolding = "None";
                Cooking.instance.handsFull = false;
                holdingThisIngredient = false;

                Debug.Log("Ingredient put away");
            }
        }
    }
}
