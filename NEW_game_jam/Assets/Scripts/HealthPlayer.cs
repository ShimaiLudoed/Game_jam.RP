using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200; // Максимальное количество здоровья игрока
    private int currentHealth; // Текущее количество здоровья игрока

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное количество здоровья
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Вычитаем урон из здоровья игрока

        // Проверяем, не стал ли игрок мёртвым
        if (currentHealth <= 0)
        {
            Die(); // Если здоровье меньше или равно нулю, вызываем метод смерти
        }
    }

    private void Die()
    {
        // Логика для смерти игрока
        Debug.Log("Игрок погиб!");
        // Дополнительные действия при смерти могут быть добавлены здесь
    }
}
