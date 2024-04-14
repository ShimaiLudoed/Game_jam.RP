using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public List<GameObject> deadEnemies = new List<GameObject>(); // Список мертвых врагов
    public float summonRange = 5f; // Радиус возрождения

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SummonAllies(); // Вызываем метод возрождения союзников при нажатии клавиши E
        }
    }

    void SummonAllies()
    {
        foreach (GameObject enemy in deadEnemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= summonRange)
            {
                enemy.SetActive(true);
                enemy.GetComponent<AIEnemy>().ReviveAndAlly(); // Вызываем метод возрождения у врага
            }
        }
    }

    // Ваши методы для добавления и удаления мертвых врагов
    public void AddDeadEnemy(GameObject enemy)
    {
        deadEnemies.Add(enemy);
    }

    public void RemoveDeadEnemy(GameObject enemy)
    {
        deadEnemies.Remove(enemy);
    }
    
}
