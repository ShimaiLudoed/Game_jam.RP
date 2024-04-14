using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool Alive = true;
    public int maxHealth=100;
    private int currentHealt;
    void Start()
    {
        currentHealt = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        if (currentHealt <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("enemy Died");
        Alive = false;
    }
}
