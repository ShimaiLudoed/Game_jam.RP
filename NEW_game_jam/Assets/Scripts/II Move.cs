using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f; // Скорость движения противника
    public float stoppingDistance = 2f; // Расстояние, на котором противник остановится перед игроком
    public float attackRange = 1f; // Расстояние для атаки

    private Transform player; // Ссылка на игрока

    private void Start()
    {
        // Находим игрока в сцене
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Если игрок существует и противник находится дальше, чем атака
        if (player != null && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            // Находим направление к игроку
            Vector2 direction = (player.position - transform.position).normalized;

            // Двигаемся в направлении игрока
            transform.Translate(direction * speed * Time.deltaTime);

            // Поворачиваем противника к игроку
            transform.right = direction;
        }
        else if (player != null && Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Атакуем игрока, если он в зоне атаки
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        // Реализуйте здесь логику атаки
        Debug.Log("Attacking player!");
    }
}
