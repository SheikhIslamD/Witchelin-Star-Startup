using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DamageDoor : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI healthDisplay;
    private DoorHealth doorHealthScript;

    public List<int> dmgOverTimeTick = new List<int>();
    void Start()
    {
        healthDisplay = GameObject.Find("HealthDisplay").GetComponent<TextMeshProUGUI>();
        Debug.Log(healthDisplay);
        doorHealthScript = GetComponent<DoorHealth>();
    }

    public void EnemyAttacksOverTime(int ticks)
    {
        if(dmgOverTimeTick.Count <= 0)
        {
            dmgOverTimeTick.Add(ticks);
            StartCoroutine(Damage());
        }
        else
        {
            dmgOverTimeTick.Add(ticks);
        }
    }
    
    IEnumerator Damage()
    {
        while(dmgOverTimeTick.Count > 0) 
        {
            for(int i = 0; i < dmgOverTimeTick.Count; i++)
            {
                dmgOverTimeTick[i]--;
            }
            doorHealthScript.health -= 1;
            healthDisplay.text = "health: "+ doorHealthScript.health;
            Debug.Log(doorHealthScript.health);
            dmgOverTimeTick.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }

    }



}
