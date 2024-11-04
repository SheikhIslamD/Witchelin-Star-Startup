using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.Events;



public class DoorEnemy : MonoBehaviour 
{
    UnityEvent<float> m_BroadcastDamage;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] private float attkInterval = 3.5f;
    public DamageDoor damageDoor;
    public int ticks;
    private DoorHealth doorHealth;
    public string monster;

    EnemySpawner es;

    //Enemy Health on Start
    private void Start()
    {
        es =  GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();

        StartCoroutine(Damage(attkInterval));
        health = maxHealth;

        switch (monster)
        {
            case "Slime":
                doorHealth = GameObject.Find("Cabniet").GetComponent<DoorHealth>();
                attkInterval = 1f;
                break;
            case "Cockatrice":
                doorHealth = GameObject.Find("CageWindow").GetComponent<DoorHealth>();
                attkInterval = 3.5f;
                break;
            case "Beholder":
                doorHealth = GameObject.Find("PantryDoor").GetComponent<DoorHealth>();
                attkInterval = 5f;
                break;
        }

    }

    //Enemy Takes Damage Destroy
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            es.SpawnEnemyCountdownBegin();
            es.CheckSpawns();
            Destroy(gameObject);            
        }
    }

   

    private IEnumerator Damage(float interval)
    {
        yield return new WaitForSeconds(attkInterval);
        damageDoor.EnemyAttacksOverTime(ticks);
        StartCoroutine(Damage(interval));
        Debug.Log("RoutineRepeat");
        doorHealth.health -= 1;
    }


}
