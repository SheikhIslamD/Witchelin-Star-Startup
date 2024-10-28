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
    

    //Enemy Health on Start
    private void Start()
    {
        
        health = maxHealth;
    }

    //Enemy Takes Damage Destroy
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>().SpawnEnemyCountdownBegin();
            Destroy(gameObject);
            
        }
    }
}
