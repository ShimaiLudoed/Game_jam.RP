using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f; // �������� �������� ����������
    public float stoppingDistance = 2f; // ����������, �� ������� ��������� ����������� ����� �������
    public float attackRange = 1f; // ���������� ��� �����

    private Transform player; // ������ �� ������

    private void Start()
    {
        // ������� ������ � �����
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // ���� ����� ���������� � ��������� ��������� ������, ��� �����
        if (player != null && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            // ������� ����������� � ������
            Vector2 direction = (player.position - transform.position).normalized;

            // ��������� � ����������� ������
            transform.Translate(direction * speed * Time.deltaTime);

            // ������������ ���������� � ������
            transform.right = direction;
        }
        else if (player != null && Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // ������� ������, ���� �� � ���� �����
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        // ���������� ����� ������ �����
        Debug.Log("Attacking player!");
    }
}
