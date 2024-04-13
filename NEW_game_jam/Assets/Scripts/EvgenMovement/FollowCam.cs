using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    public bool playerFollow = true;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (playerFollow == true)
        {
            CameraFollowPlayer();
        }
    }

    public void SetFollowPlayer(bool val)
    {
        playerFollow = val;
    }

    public void CameraFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        this.transform.position = newPos;
    }
}
