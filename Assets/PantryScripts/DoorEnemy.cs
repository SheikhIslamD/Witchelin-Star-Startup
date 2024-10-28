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

    //Enemy Health on Start
    private void Start()
    {
        StartCoroutine(Damage(attkInterval));
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

   

    private IEnumerator Damage(float interval)
    {
        yield return new WaitForSeconds(attkInterval);
        damageDoor.EnemyAttacksOverTime(ticks);
        StartCoroutine(Damage(interval));
        Debug.Log("RoutineRepeat");
    }


}
