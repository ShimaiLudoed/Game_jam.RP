using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public AIEnemy enemy;
    
    public int maxHealth = 300;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamagePlayer(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("YOU ARE DEAD!");
    }
    
}
public class PlayerHealth : MonoBehaviour
{
    // Событие или делегат для смерти игрока
    public static event System.Action PlayerDeath;

    public void Die()
    {
        // Вызываем событие о смерти игрока, если есть подписчики
        PlayerDeath?.Invoke();
    }
}