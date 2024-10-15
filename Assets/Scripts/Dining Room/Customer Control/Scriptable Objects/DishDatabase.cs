using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DishDatabase", menuName = "Assets/Databases/DishDatabase")]
public class DishDatabase : ScriptableObject
{
    public List<Dish> slimeDishes;
    public List<Dish> cockDishes;
    public List<Dish> beholderDishes;
}
