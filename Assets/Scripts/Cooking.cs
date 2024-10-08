using System;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    public TextMeshProUGUI cookingCountdownText;
    public bool currentlyCooking; //if stove is running
    public float cookTime; //how long to cooking takes
    public Image handsImage; //image to show hand status

    public bool handsFull; //if anything is held already
    public bool holdingCookedFood; //if the item held is a completed cooked food

    //public IngredientButton[] ingredientBoxes;
    public string handsHolding; //what is held in the hands
    public List<string> orders; //what orders there currently are (type these in inspector)
    public string whatsCooking; //what is on the stove cooking

    public GameObject CollectCookedFood;
    public IngredientButton ingredientButton;

    //public TextMeshProUGUI platedText;

    //for making this a singleton
    public static Cooking instance;
    void Awake()
    {
        //for making this a singleton
        if (instance == null)
        {
            instance = this;
        }

        //make hands blank
        handsImage.color = Color.clear;
        //hide the collect cooked food button
        CollectCookedFood.SetActive(false);
    }

    void Update()
    {
        if (currentlyCooking) 
        {
            if (cookTime > 0) 
            {
                cookTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(cookTime / 60);
                int seconds = Mathf.FloorToInt(cookTime % 60);
                cookingCountdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (cookTime < 0)
            {
                cookTime = 0;
                currentlyCooking = false;
                CollectCookedFood.SetActive(true);
            }
        }
    }

    public void PlaceIngredient()
    {
        if (!currentlyCooking && !holdingCookedFood)
        {
            foreach (string order in orders)
            {
                if (order == handsHolding)
                {
                    StartCookingStove();
                    Debug.Log("Order found, starting to cook");
                }
            }
        }
        else
            Debug.Log("Wrong order or Already busy cooking!");
    }
    public void StartCookingStove()
    {
        //redundant if check here?
        if (!currentlyCooking)
        {
            whatsCooking = handsHolding;
            handsHolding = "None";
            handsImage.color = Color.clear;
            cookTime = 10;
            handsFull = false;
            currentlyCooking = true;
            ingredientButton.holdingThisIngredient = false;
        }
    }
    public void Plating()
    {
        if (holdingCookedFood)
        {
            foreach (string order in orders)
            {
                if (order.Contains(handsHolding))
                {
                    handsHolding = "None";
                    handsImage.color = Color.clear;
                    handsFull = false;
                    holdingCookedFood = false;
                    Debug.Log("Correct cooked order, accepted!");
                }
            }
        }
    }
    public void FinishCookingStove()
    {
        if (!currentlyCooking)
        {
            handsHolding = whatsCooking;
            handsFull = true;
            holdingCookedFood = true;
            whatsCooking = "None";
            handsImage.color = Color.green;
            CollectCookedFood.SetActive(false);
        }
    }
}
