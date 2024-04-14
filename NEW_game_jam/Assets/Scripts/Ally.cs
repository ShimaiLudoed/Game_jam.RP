using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public float speed;
    public Transform Point;
    public int PosOfPat;
    private bool MovingRight = true;
    private Transform player;
    public float StoppingDistance;
    private bool chill = false;
    private bool angry = false;
    private Transform enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    
    void Update()
    {
      
        if (Vector2.Distance(transform.position, player.position) < PosOfPat&&angry==false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, enemy.position) < StoppingDistance)
        {
            angry = true;
            chill = false;
        }
        

        if (chill==true)
        {
            Chill();
        }

        else if (angry==true)
        {
            Angry();
        }
    }

    void Chill()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
    }
}
