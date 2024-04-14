using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform target; // цель, за которой должны следовать союзные персонажи
    public float followDistance = 3f; // расстояние, на котором должны находиться союзные персонажи от цели
    public float attackRange = 1f; // расстояние, на котором союзные персонажи должны начинать атаковать врагов
    public int speed;
    private void Update()
    {
        if (target != null)
        {
            // Рассчитываем расстояние между текущим персонажем и целью
            float distance = Vector2.Distance(transform.position, target.position);

            // Если расстояние больше followDistance, двигаемся к цели
            if (distance > followDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
            }

            // Если расстояние меньше attackRange, атакуем ближайшего врага
            if (distance < attackRange)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        // Реализация атаки на ближайшего врага 
        // Например, вызов анимации атаки или уменьшение здоровья врага
    }

}
