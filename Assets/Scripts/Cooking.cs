using System;
using System.Collections;
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
    //public float cookTime; //how long to cooking takes
    //public Image handsImage; //image to show hand status

    //public bool handsFull; //if anything is held already
    //public bool holdingCookedFood; //if the item held is a completed cooked food

    //public string handsHolding; //what is held in the hands
    //public List<string> orders; //what orders there currently are (type these in inspector)
    public GameObject whatsCooking; //what is on the stove cooking

    public GameObject Pickup;

    public GameObject platedTransform;
    public GameObject cookingTransform;

    //new cooking system
    public Slider timeSlider;
    public Image timeSliderColor;

    //for making this a singleton
    public static Cooking instance;
    void Awake()
    {
        //for making this a singleton
        if (instance == null)
        {
            instance = this;
        }

        currentlyCooking = false;
        //hide the collect cooked food button
        Pickup.SetActive(false);
    }
    public void PlaceIngredient()
    {
        //checks if something is already cooking, and if the player is holding an uncooked item
        if (!currentlyCooking && PlayerHands.instance.heldItem.GetComponent<Ingredient>().cookState == 0)
        {
            //write the item to whatsCooking and move it to the stove, remove from player's hands
            whatsCooking = PlayerHands.instance.heldItem;
            PlayerHands.instance.PutDown();
            whatsCooking.transform.SetParent(cookingTransform.transform, true);
            whatsCooking.transform.position = cookingTransform.transform.position;
            //begin the cooking coroutine and allow picking up the item
            BeginCooking(0);
            Pickup.SetActive(true);
            Debug.Log("Starting to cook a " + whatsCooking.GetComponent<Ingredient>().IngredientName);
        }
        else
            Debug.Log("Can't cook that, or already cooking!");
    }

    public void BeginCooking(float cookTime)
    {
        timeSlider.maxValue = whatsCooking.GetComponent<Ingredient>().cookMax;
        timeSlider.value = 0;
        currentlyCooking = true;
        StartCoroutine(CookingCountdown(cookTime));
    }

    public void StopCooking()
    {
        currentlyCooking = false;
        Debug.Log("Cooking Stopped");
    }

    IEnumerator CookingCountdown(float cookTime)
    {
        while (currentlyCooking)
        {
            int minutes = Mathf.FloorToInt(cookTime / 60);
            int seconds = Mathf.FloorToInt(cookTime % 60);
            cookingCountdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            cookTime += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            //keep running while curruntly cooking
            if (currentlyCooking)
            {
                timeSlider.value = cookTime;
            }

            //red if undercooked
            if (cookTime < whatsCooking.GetComponent<Ingredient>().cookMin)
            {
                whatsCooking.GetComponent<Ingredient>().cookState = 0;
                timeSliderColor.color = Color.red;
            }
            //making the food item take on the proper cook state, if higher than min but below max then it's perfectly cooked
            if (cookTime >= whatsCooking.GetComponent<Ingredient>().cookMin && cookTime <= whatsCooking.GetComponent<Ingredient>().cookMax)
            {
                whatsCooking.GetComponent<Ingredient>().cookState = 1;
                whatsCooking.GetComponent<Ingredient>().CookUpdate();
                timeSliderColor.color = Color.green;
            }
            //make it burnt if it goes to max cooktime and make currentlycooking off
            if (cookTime > whatsCooking.GetComponent<Ingredient>().cookMax)
            {
                whatsCooking.GetComponent<Ingredient>().cookState = 2;
                whatsCooking.GetComponent<Ingredient>().CookUpdate();
                timeSliderColor.color = Color.black;
                StopCooking();
            }
        }
    }

    public void PickupIngredient()
    {
        if (!PlayerHands.instance.handsFull)
        {
            StopCooking();
            PlayerHands.instance.PickUp(whatsCooking);
            whatsCooking = null;
            Pickup.SetActive(false);
        }
    }

    public void Plating()
    {
        GameObject platedfood = PlayerHands.instance.heldItem;
        PlayerHands.instance.PutDown();
        platedfood.transform.SetParent(platedTransform.transform, true);
        platedfood.transform.position = platedTransform.transform.position;
    }

    public void Trashcan()
    {
        Destroy(PlayerHands.instance.heldItem);
        PlayerHands.instance.PutDown();
        Debug.Log("Item trashed");
    }

    /*    void Update()
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
        }*/

    /*    public void StartCookingStove()
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
            }
        }*/
    /*    public void Plating()
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
        }*/
    /*    public void FinishCookingStove()
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
        }*/


}