using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public AIEnemy enemy;
    
    public Transform PointerSummon;
    private Transform dead;
    public Transform Ally;
    
    public float radiusSummon;
    public List<GameObject> deadEnemies = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Summoning();
        }
    }

    public void Summoning()
    {
        GameObject[] deadEnemiesArray = GameObject.FindGameObjectsWithTag("Dead"); // Получаем все мертвые враги
        
        foreach (GameObject deadEnemy in deadEnemiesArray)
        {
            if (Vector2.Distance(transform.position, deadEnemy.transform.position) < radiusSummon)
            {
                // Добавляем мертвых врагов в лист мертвых врагов
                deadEnemies.Add(deadEnemy);

                Debug.Log("Summoning " + deadEnemy.name + " as an alty!");
            }
        }

        foreach (GameObject deadEnemy in deadEnemies)
        {
            Transform allyTransform = Instantiate(Ally, deadEnemy.transform.position, Quaternion.identity);
            Destroy(deadEnemy);
        }
        deadEnemies.Clear(); // Очищаем список мертвых врагов
    }
    
    private void OnDrawGizmosSelected() // Метод для визуализации радиуса атаки в редакторе
    { 
        if (PointerSummon == null) 
        { 
            return; 
        } 
        Gizmos.DrawWireSphere(PointerSummon.position, radiusSummon); 
    } 
}