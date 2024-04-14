using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyContrl : MonoBehaviour
{
    public bool isAlly = false;

    public void MakeAlly()
    {
        isAlly = true;
        Debug.Log("Enemy has become an ally!");
        // Дополнительные действия при смене статуса
    }

    

}
