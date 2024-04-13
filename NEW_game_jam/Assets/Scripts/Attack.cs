using System;
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
          
            attack();
        }
    }

    public void attack()
    {
        Collider2D[] hitEnemy= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLay);

        foreach (Collider2D enemy in hitEnemy)
        {
            
         Debug.Log("We hit"+enemy.name);   
         enemy.GetComponent<Enemy>().TakeDamage(attackDamge);
         
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
