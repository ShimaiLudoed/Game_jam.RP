using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject HitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}