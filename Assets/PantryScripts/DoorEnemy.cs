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

    private void Start()
    {
        
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
