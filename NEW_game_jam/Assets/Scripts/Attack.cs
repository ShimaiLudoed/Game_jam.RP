using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    //public Animator animator;
    public LayerMask EnemyLay;
    public float attackRange = 0.5f;

    public int attackDamage = 40;

    // Флаг для отслеживания состояния атаки
    private bool isAttacking = false;

    // Используйте один метод Update для обработки ввода и вызова атаки
    void Update()
    {
        // Проверяем, если атака уже идет, то выходим из метода
        if (isAttacking)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Запускаем корутину для атаки
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        // Устанавливаем флаг атаки в true
        isAttacking = true;

        //player animation 

        //detected enemy 
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLay);
        //damage 
        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }

        // Ждем некоторое время перед следующей атакой (например, 0.5 секунды)
        yield return new WaitForSeconds(0.5f);

        // Устанавливаем флаг атаки в false
        isAttacking = false;
    }

    // Метод для визуализации радиуса атаки в редакторе
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}





/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public Animator animator;
    public LayerMask EnemyLay;
    public float attackRange = 0.5f;

    public int attackDamge = 40;
    //cредний фаербол
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            attackEnemy();
        }
    }

    public void attackEnemy()
    {
        //player animation

        //detected enem
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLay);
        //damage
        foreach (Collider2D enemy in hitEnemy)
        {

            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamge);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

*/