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

    public Sprite[] resultSprites;
    [Space(10)]

    [Header("Dish Information")]
    public string dishName;
    public int cookMethod;
    public bool isPlated;
    public Sprite dishSprite;

    public Sprite[] cockDishSprites;
    public Sprite[] slimeDishSprites;
    public Sprite[] beholderDishSprites;

    public Image image;

    void Start()
    {
        IngredientName = protein.IngredientName;
        cookMin = protein.cookMin;
        cookMax = protein.cookMax;
        cookState = protein.cookState;
        proteinSprite = protein.proteinSprite;
        resultSprites = protein.resultSprites;

        dishName = protein.dishName;
        cookMethod = protein.cookMethod;
        dishSprite = protein.dishSprite;


        image = GetComponent<Image>();
    }

    public void CookUpdate()
    {
        image.sprite = resultSprites[cookState];
        
    }

    public void PlatingUpdate()
    {
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
