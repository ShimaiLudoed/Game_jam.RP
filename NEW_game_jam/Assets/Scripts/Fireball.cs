using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public AIEnemy enemy;
    
    public GameObject HitEffect;
    public int damage = 25;
    void OnCollisionEnter2D(Collision2D collision)
    {
        AIEnemy enemy = collision.gameObject.GetComponent<AIEnemy>();

        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}