using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public Necromancer necro;
    public PlayerInfo PI;
    public AIAlly AA;
    
    private Transform player;
    private Transform ally;
    private Transform nose;
    public LayerMask PlayerLay;
    
    public float fov;
    public float speed;
    public float attackRange = 1.5f;
    public int maxHealth;
    public int currentHealt;
    public int damage = 20;
    public bool atacking = false;
    
    public bool alive = true;
    private bool angry = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ally = GameObject.FindGameObjectWithTag("Ally").transform;
        
        PI = FindObjectOfType<PlayerInfo>();
        AA = FindObjectOfType<AIAlly>();
        
        currentHealt = maxHealth;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < fov || Vector2.Distance(transform.position, ally.position) < fov)
        {
            Angry();
        }
        
        if (Vector2.Distance(transform.position, player.position) < attackRange || Vector2.Distance(transform.position, ally.position) < attackRange)
        { 
            StartCoroutine(AttackCoroutine());
        } 
    }
    
    public void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (AA.tag == "DeadAlly")
        {
            Angry();
        }
    }
    
    IEnumerator AttackCoroutine() 
    {
        if (AA.gameObject.tag != "DeadAlly")
        {
            atacking = true;
        
            Debug.Log("Ally was hitted from " + player.name);
            AA.TakeDamageAlly(damage);
        
            yield return new WaitForSeconds(1f); //кулдаун на атаку
        
            atacking = false;
        }
        
        atacking = true;
        
        Debug.Log("You was hitted from " + player.name);
        PI.TakeDamagePlayer(damage);
        
        yield return new WaitForSeconds(1f); //кулдаун на атаку
        
        atacking = false;
    } 

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        if (currentHealt <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        alive = false;
        //necro.AddDeadEnemy(gameObject);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.tag = "Dead";
    }
    
    public void ReviveAndAlly()
    {
        alive = true;
    }
    
    private void OnDrawGizmosSelected() // Метод для визуализации радиуса атаки в редакторе
    { 
        if (nose == null) 
        { 
            return; 
        } 
        Gizmos.DrawWireSphere(nose.position, attackRange); 
    } 
}
