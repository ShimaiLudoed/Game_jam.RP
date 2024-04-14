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
    public float attackRange;
    public int maxHealth;
    public int currentHealt;
    public int damage;
    public int desiredChillDistance;
    

    public bool alive = true;
    private bool angry = false;
    private bool chill = true;
    public bool atacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        AE = FindObjectOfType<AIEnemy>();

        currentHealt = maxHealth;
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

        if (angry == true)
        {
            Angry();
        }

        if (chill == true)
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
    }

    void Chill()
    {
        if (Vector2.Distance(transform.position, player.position) > desiredChillDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);

        if (AE.tag == "Dead")
        {
            angry = false;
            chill = true;
            Chill();
        }
    }

    IEnumerator AttackCoroutine()
    {
        atacking = true;

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(nose.position, attackRange, EnemyLay);

        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log("Boss, I hitted  " + enemy.name);
            enemy.GetComponent<AIEnemy>().TakeDamage(damage);

            if (AE.alive == false)
            {
                Debug.Log("Boss, I KILLED  " + enemy.name);
            }
        }

        yield return new WaitForSeconds(1f); //кулдаун на атаку 5 мс

        atacking = false;
    }

    public void TakeDamageAlly(int damage)
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
        GetComponent<Collider2D>().enabled = false;
        gameObject.tag = "DeadAlly";
        this.enabled = false;
    }

    public void ReviveAndAlly()
    {
        alive = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (nose == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(nose.position, attackRange);
    }
}