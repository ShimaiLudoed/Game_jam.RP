using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    //public Necromancer necro;
    public PlayerInfo PI;                         //экземпляр игрока (player)
    public AIAlly AA;                             //экзепляр союзника (ally)
    
    private Transform player;                     //ссылка на игрока (player)
    private Transform ally;                       //ссылка на союзника (ally)
    public Transform nose;                        //ссылка на "нос" - куда смотрит юнит
    public LayerMask PlayerLay;
    public LayerMask AllyLay;
    
    public float fov;                             //поле зрения
    public float speed;                           //скорость передвижения
    public float attackRange = 1.5f;              //радиус атаки
    public int maxHealth;                         //максимальное здоровье
    public int currentHealt;                      //актуальное здоровье
    public int damage;                            //урон в секунду
    
    
    public bool atacking = false;                 //статус атаки (атакует или нет)
    public bool alive = true;                     //статус жив/мёртв
    private bool angry = false;                   //статус атаки

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
        if (Vector2.Distance(transform.position, player.position) < fov)
        {
            AngryPlayer();
        }
        
        if (Vector2.Distance(transform.position, player.position) < attackRange)
        {
            StartCoroutine(AttackCoroutinePlayer());
        }

        if (Vector2.Distance(transform.position, ally.position) < fov)
        {
            AngryAlly();
        }

        if (Vector2.Distance(transform.position, ally.position) < attackRange)
        {
            StartCoroutine(AttackCoroutineAlly());
        }
        
    }
    
    public void AngryPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > attackRange - 1f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    
    public void AngryAlly()
    {
        if (Vector2.Distance(transform.position, ally.position) > attackRange - 1f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, ally.position, speed * Time.deltaTime);
        }

        if (AA.tag == "DeadAlly")
        {
            AngryPlayer();
        }
    }
    
    IEnumerator AttackCoroutinePlayer() 
    {
        if (!atacking)  // Проверяем, не атакует ли враг уже
        {
            atacking = true;  // Устанавливаем статус атаки

            Debug.Log("You were hit by the enemy");
            PI.TakeDamagePlayer(damage);

            yield return new WaitForSeconds(1f);  // Задержка на перезарядку атаки

            atacking = false;  // После перезарядки сбрасываем статус атаки
        }
    }
    
    IEnumerator AttackCoroutineAlly() 
    {
        if (!atacking)  // Проверяем, не атакует ли враг уже
        {
            atacking = true;  // Устанавливаем статус атаки

            Debug.Log("You were hit by the enemy");
            AA.TakeDamageAlly(damage);

            yield return new WaitForSeconds(1f);  // Задержка на перезарядку атаки

            atacking = false;  // После перезарядки сбрасываем статус атаки
        }
    }
    

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        if (currentHealt <= 0)
        {
            atacking = false;
            Dead();
        }
    }

    public void Dead()
    {
        alive = false;
        atacking = false;
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