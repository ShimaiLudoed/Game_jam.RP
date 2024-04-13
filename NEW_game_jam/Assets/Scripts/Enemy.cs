using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 150;

    private int currentHealth;

     void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Taking damage: " +  damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
