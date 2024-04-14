using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAlly : MonoBehaviour
{
    public Necromancer necro;
    public AIEnemy AE;

    private Transform player;
    private Transform enemy;
    public Transform nose;
    public LayerMask EnemyLay;
    
    public float fov;
    public float speed;
    public float attackRange = 1.5f;
    public int maxHealth;
    public int currentHealt;
    public int damage = 20;
    public int playerCheck;
    
    public bool alive = true;
    private bool angry = false;
    private bool chill = true;
    public bool atacking = false;
    
    public List<Transform> allEnemies = new List<Transform>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        AE = FindObjectOfType<AIEnemy>();
        
        currentHealt = maxHealth;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            allEnemies.Add(enemy.transform);
        }
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, enemy.position) < fov && AE.alive == true)
        {
            chill = false;
            angry = true;
        }
        else if (Vector2.Distance(transform.position, enemy.position) > fov)
        {
            angry = false;
            chill = true;
        }

        if (angry)
        {
            Angry();
        }
        
        if (chill)
        {
            Chill();
        }
        
        if (atacking) 
        { 
            return;
        } 
        
        if (Vector2.Distance(transform.position, enemy.position) < attackRange)
        { 
            StartCoroutine(AttackCoroutine());
        }

        if (allEnemies.Count == 0)
        {
            Chill();
        }
    }

    void Chill()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    
    public void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
    }
    
    IEnumerator AttackCoroutine()
    { 
        atacking = true; 
        
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(nose.position, attackRange, EnemyLay);
        
        foreach (Collider2D enemyCollider in hitEnemy) 
        { 
            Debug.Log("Boss, I hitted " + enemyCollider.name);
            
            enemyCollider.GetComponent<AIEnemy>().TakeDamage(damage);
            
            if (!enemyCollider.GetComponent<AIEnemy>().alive)
            {
                Debug.Log("Boss, I KILLED " + enemyCollider.name);
                allEnemies.Remove(enemyCollider.transform);
            }
        } 
        
        if (allEnemies.Count > 0)
        {
            enemy = allEnemies[Random.Range(0, allEnemies.Count)];
        }
        
        yield return new WaitForSeconds(1f); 
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