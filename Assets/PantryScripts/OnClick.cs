using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour
{
    public Button yourButton;

    
    public void TaskOnClick()
    {
        
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<DoorEnemy>()?.TakeDamage(1f);

    }
}
