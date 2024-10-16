using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class DoorEnemy : MonoBehaviour 
{
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
