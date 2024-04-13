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
    
    //cредний фаербол
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
          
            attack();
        }
    }

    public void attack()
    {
        //player animation
      
        //detected enem
        Collider2D[] hitEnemy= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLay);
        //damage
        foreach (Collider2D enemy in hitEnemy)
        {
         Debug.Log("We hit"+enemy.name);   
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
