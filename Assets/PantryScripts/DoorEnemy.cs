using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.Events;



public class DoorEnemy : MonoBehaviour 
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] private float attkInterval = 3.5f;
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
                Debug.Log("Beholder found PantryDoor!");
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
            es.SpawnEnemyCountdownBegin(monster);
            es.CheckSpawns(monster);
            Destroy(gameObject);            
        }
    }

   

    private IEnumerator Damage(float interval)
    {
        yield return new WaitForSeconds(attkInterval);
        StartCoroutine(Damage(interval));
        Debug.Log("RoutineRepeat");
        doorHealth.health -= 1;
    }


}
