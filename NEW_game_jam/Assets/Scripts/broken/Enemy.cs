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
        if (alive)
        {
            if (IsPlayerVisible())
            {
                Agressive();
            }
            else
            {
                Chill();
            }
        }
    }

    protected bool IsPlayerVisible()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= fov)  // Проверяем расстояние до игрока
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector3.Angle(transform.up, directionToPlayer);
            // Проверяем угол между направлением взгляда противника и направлением к игроку
            
            if (angleToPlayer <= fov / 2)
            // Проверяем, находится ли игрок в поле зрения противника (угол меньше половины угла зрения)    
            {
                return true;
            }
        }
        return false;
    }
    protected virtual void Chill()
    {
        
    }

    protected virtual void Agressive()
    {
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
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