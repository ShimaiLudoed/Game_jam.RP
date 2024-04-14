using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isAlive = true; // Добавляем переменную для отслеживания жив ли враг

    public void Die()
    {
        isAlive = false;
        // Логика смерти врага
    }

    public void ReviveAndAlly()
    {
        isAlive = true;
        // Логика оживления врага в качестве союзника
    }
}

public class EnemyControl : MonoBehaviour
{
    // Логика управления врагом
    public void ReviveAndAlly()
    {
        // Логика оживления врага в качестве союзника
    }
}
