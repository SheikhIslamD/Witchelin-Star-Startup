using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    //be able to plug in and read from scriptableobject protein entries
    public Protein protein;

    [Header("Ingredient Information")]
    public string IngredientName;

    public float cookMin;
    public float cookMax;

    public int cookState = 0;

    public Sprite proteinSprite;
    [Space(10)]

    [Header("Dish Information")]
    public string dishName;
    public int cookMethod;
    public Sprite dishSprite;

    public Sprite[] resultSprites;

    public bool isPlated;
    public Sprite[] cockDishSprites;
    public Sprite[] slimeDishSprites;
    public Sprite[] beholderDishSprites;

    public Image image;

    void Start()
    {
        //assign all values from scriptable object
        IngredientName = protein.IngredientName;
        cookMin = protein.cookMin;
        cookMax = protein.cookMax;
        cookState = protein.cookState;
        proteinSprite = protein.proteinSprite;

        dishName = protein.dishName;
        cookMethod = protein.cookMethod;
        dishSprite = protein.dishSprite;

        resultSprites = protein.resultSprites;


        image = GetComponent<Image>();
        image.sprite = proteinSprite;
    }

/*    public void IngredientUpdate()
    {
        IngredientName = protein.IngredientName;
        cookMin = protein.cookMin;
        cookMax = protein.cookMax;
        cookState = protein.cookState;
        proteinSprite = protein.proteinSprite;

        dishName = protein.dishName;
        cookMethod = protein.cookMethod;
        dishSprite = protein.dishSprite;

        resultSprites = protein.resultSprites;
    }*/

    public void CookUpdate(int cookState)
    {
        //image.sprite = resultSprites[cookState];
        switch (cookState) 
        {
            case 0: //color FFA3BD //color 9D4B2C //color 
                image.color = new Color32(255, 163, 189, 255);
                Debug.Log("raw color assigned");
                break;
            case 1: //color FFA3BD //color 9D4B2C //color 
                image.color = new Color32(157, 75, 44, 255);
                Debug.Log("cooked color assigned");
                break;
            case 2: //color FFA3BD //color 9D4B2C //color 
                image.color = new Color32(31, 20, 16, 255);
                Debug.Log("burnt color assigned");
                break;
        }
    }

    public void PlatingUpdate()
    {
        image.color = Color.white;
        isPlated = true;
        //make a burnt dish example to show serving it displeases customers?
        if (cookState == 2)
        {
            
        }

        //only assign dish details if it is perfectly cooked
        if (cookState == 1)
        {
            switch (IngredientName)
            {
                //add new base ingredients here
                case "Cock":
                    //dish sprite assigned here based on cooking method (0 = oven, 1 = pan, 2 = fryer)
                    switch (cookMethod)
                    {
                        case 0:
                            dishName = "Rotisserie";
                            break;
                        case 1:
                            dishName = "Omutrice";
                            break;
                        case 2:
                            dishName = "Wings";
                            break;
                    }
                    image.sprite = cockDishSprites[cookMethod];
                    break;
                case "Slime":
                    switch (cookMethod)
                    {
                        case 0:
                            dishName = "Gelatinous Casserole";
                            break;
                        case 1:
                            dishName = "Slime Brulee";
                            break;
                        case 2:
                            dishName = "Fried Glop";
                            break;
                    }
                    image.sprite = slimeDishSprites[cookMethod];
                    break;
                case "Beholder":
                    switch (cookMethod)
                    {
                        case 0:
                            dishName = "Cornea and Tentacle Lasagna";
                            break;
                        case 1:
                            dishName = "Eyeball e pepe";
                            break;
                        case 2:
                            dishName = "Beholder Takoyaki";
                            break;
                    }
                    image.sprite = beholderDishSprites[cookMethod];
                    break;
            }
        }
    }
}
