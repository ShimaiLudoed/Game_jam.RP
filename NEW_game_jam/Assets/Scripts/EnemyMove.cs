using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public Transform Point;
    public int PosOfPat;
    private bool MovingRight = true;
    private Transform player;
    public float StoppingDistance;
    private bool chill = false;
    private bool angry = false;
 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, Point.position) < PosOfPat&&angry==false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < StoppingDistance)
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
        if (transform.position.x > Point.position.x + PosOfPat)
        {
            MovingRight = false;
        }
        else if (transform.position.x > Point.position.x - PosOfPat)
        {
            MovingRight = true;
        }

        if (MovingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else 
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    
}
