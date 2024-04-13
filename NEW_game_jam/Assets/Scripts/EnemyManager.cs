using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Enemy
{
    protected override void Start()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        speed = 2f;
        damage = 10;
        fov = 5f;
        base.Start(); // Вызов метода Start() из базового класса
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Dead()
    {
        base.Dead();
        // Логика для состояния "Мёртвый" для конкретного типа врага Peasant
    }
    
        
    [ExecuteInEditMode]
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fov);
    }
}
