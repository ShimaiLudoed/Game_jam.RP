using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform player; // ссылка на главного героя
    public float followDistance = 3f; // расстояние, на котором персонаж должен следовать за игроком
    public float attackDistance = 1f; // расстояние, на котором персонаж должен атаковать врага

    private Transform target; // цель, за которой следит персонаж
    private bool isAttacking = false; // флаг для проверки, атакует ли персонаж врага


    private void Start()
    {

        
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (!target)
        {
            if (distanceToPlayer < followDistance)
            {
                target = player;
            }
            else
            {
                // возвращаемся к главному герою
                transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime);
            }
        }
        else
        {
            if (distanceToPlayer > followDistance)
            {
                target = null;
            }
            else if (distanceToPlayer < attackDistance)
            {
                isAttacking = true;
            }
            
            if (isAttacking)
            {
                // атакуем врага
                target.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    
                if (Vector2.Distance(transform.position, target.position) < 0.1f)
                {
                    Destroy(target.gameObject);
                    target = null;
                    isAttacking = false;
                }
            }
        }
    } 
}
