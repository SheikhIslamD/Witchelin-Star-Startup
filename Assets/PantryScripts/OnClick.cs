using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        
            gameObject.TryGetComponent<DoorEnemy>(out DoorEnemy enemyComponent);
        enemyComponent.TakeDamage(1);
        
    }
}
