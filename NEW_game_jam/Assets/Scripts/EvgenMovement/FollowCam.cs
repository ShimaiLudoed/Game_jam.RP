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
        
    }
}
