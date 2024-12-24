using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyMaxHealth;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    private void Update()
    {
        EnemyDie(); 
    }

    private void EnemyDie()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
