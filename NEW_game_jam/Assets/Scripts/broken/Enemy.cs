using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected bool alive = true;
    protected int maxHealth;
    protected int currentHealth;
    protected float speed;
    protected int damage;
    protected float fov;

    protected Transform player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
      
    }
    
    protected virtual void Dead()
    {
        
    }

    public abstract void TakeDamage(int damage);

    protected virtual void Die()
    {
        Debug.Log("ENEMY DEAD");
        alive = false;
        Dead();
    }
}