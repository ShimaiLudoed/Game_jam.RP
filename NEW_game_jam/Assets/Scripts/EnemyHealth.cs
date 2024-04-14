using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool Alive = true;
    public int maxHealth=100;
    public int currentHealt;
    private EnemyController _enemyContrl;
    
    void Start()
    {
        currentHealt = maxHealth;
    }

 

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        if (currentHealt <= 0)
        {
            _enemyContrl.Die();
        }
        
    }
}
