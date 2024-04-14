using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class Melee : MonoBehaviour 
{ 
    public Transform attackPoint; 
    //public Animator animator; 
    public LayerMask EnemyLay; 
    public float attackRange = 0.5f; 
 
    public int attackDamage = 40; 
    
    private bool isAttacking = false;
    
    void Update() 
    { 
        if (isAttacking) 
        { 
            return; 
        } 
 
        if (Input.GetMouseButtonDown(0)) 
        { 
            StartCoroutine(AttackCoroutine()); 
        } 
    } 
 
    IEnumerator AttackCoroutine() 
    { 
        isAttacking = true; 
        
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLay);
        
        foreach (Collider2D enemy in hitEnemy) 
        { 
            Debug.Log("We hit " + enemy.name); 
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage); 
        } 
        
        yield return new WaitForSeconds(0.5f); //кулдаун на атаку 5 мс
        
        isAttacking = false; 
    } 
    
    private void OnDrawGizmosSelected() // Метод для визуализации радиуса атаки в редакторе
    { 
        if (attackPoint == null) 
        { 
            return; 
        } 
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    } 
}