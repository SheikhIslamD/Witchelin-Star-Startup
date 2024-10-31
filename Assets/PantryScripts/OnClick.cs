using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour
{
    public Button yourButton;
    public GameObject[] Monsters;
    public string targetSpawn;
    //Cabniet CageWindow PantryDoor


    //On Click Damage Enemy
    public void TaskOnClick()
    {
        
        Monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject Monster in Monsters){
            if (Monster.GetComponent<DoorEnemy>().monster == targetSpawn) { 
                Monster.GetComponent<DoorEnemy>().TakeDamage(1f);
            }
        }
    }
}
