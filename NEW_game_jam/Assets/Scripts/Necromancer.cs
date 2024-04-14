using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public KeyCode summonKey = KeyCode.E;
    public float summonRange = 5f;
    public LayerMask enemyLayer;
    public EnemyHealth enem;
    private List<GameObject> deadEnemies = new List<GameObject>();
    private Transform Enemy;

    void Update()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (Input.GetKeyDown(summonKey))
        {
            foreach (GameObject enemy in deadEnemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) <= summonRange)
                {
                    // Возродить врага
                    enemy.SetActive(true);
                    // Сделать врага союзником
                    enemy.GetComponent<enemyContrl>().MakeAlly();
                }
            }
        }
    }

    public void AddDeadEnemy(GameObject enemy)
    {
        if (enem.currentHealt == 0)
        {
            deadEnemies.Add(enemy);
        }
        
    }

    public void RemoveDeadEnemy(GameObject enemy)
    {
        deadEnemies.Remove(enemy);
    }
}
