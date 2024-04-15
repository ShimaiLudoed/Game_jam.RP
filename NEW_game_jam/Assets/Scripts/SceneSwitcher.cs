using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToStartScene()
    {
        SceneManager.LoadScene("Main Meny"); // Загружаем начальную сцену
    }
}

