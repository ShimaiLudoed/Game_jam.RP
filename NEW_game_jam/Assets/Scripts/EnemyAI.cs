using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public bool moving = true;
    public bool patrol = true;
    public bool clockwise = false;
    public bool gaurd = false;
    public bool pursuingPlayer = false;
    public bool goingToLastLoc = false;
    Vector3 targer;
    private Rigidbody2D rid;
    public Vector3 playerLastPos;
    RaycastHit2D hit;
    public float speed = 2.0f;
    public int layerMask = 1 << 0;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLastPos = this.transform.position;
        //
        rid = this.GetComponent<Rigidbody2D>();
        layerMask = ~layerMask;
    }

    public void Update()
    {
        Movement();
        PlayerDetected();
    }

    public void Movement()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        Vector3 dir = player.transform.position - transform.position;
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist, layerMask);
        Debug.DrawRay(transform.position, dir, Color.red);

        Vector3 fwt = this.transform.TransformDirection(Vector3.right);

        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(fwt.x, fwt.y),1.0f, layerMask);

        if (moving == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (patrol == true)
        {
            Debug.Log("Patrolling normally");
            speed = 2.0f;

            if (hit2.collider != null)
            {
                if (hit2.collider.gameObject.tag == "Wall")
                {
                    if (clockwise == false)
                    {
                        transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
        }

        if (pursuingPlayer == true)
        {
            Debug.Log("Pursing Player");
            speed = 3.5f;
            rid.transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2((playerLastPos.y - transform.position.y),
                    (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg); 
        }

        if (goingToLastLoc == true)
        {
            Debug.Log("Check last known player location");
            speed = 3.0f;
            rid.transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) *
                Mathf.Rad2Deg);

            if (Vector3.Distance(this.transform.position, playerLastPos) < 1.5f)
            {
                patrol = true;
                goingToLastLoc = false;
            }
        }
    }

    public void PlayerDetected()
    {
        Vector3 pos = this.transform.InverseTransformPoint(player.transform.position);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player" && pos.x > 1.2f &&
                Vector3.Distance(this.transform.position, player.transform.position) < 9)
            {
                patrol = false;
                pursuingPlayer = true;
            }
            else if (pursuingPlayer == true)
            {
                goingToLastLoc = true;
                pursuingPlayer = false;
            }
        }
    }
}