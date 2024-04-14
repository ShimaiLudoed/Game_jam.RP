using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        // Подписываемся на событие о смерти игрока
        PlayerHealth.PlayerDeath += HandlePlayerDeath;
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        PlayerHealth.PlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        // Загружаем другую сцену с началом игры
        SceneManager.LoadScene("Main Meny");
    }
}

