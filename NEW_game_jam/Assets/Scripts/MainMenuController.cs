using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Загрузить сцену с игрой (с предварительным настройками загрузки)
        SceneManager.LoadScene("SampleScene");
    }
}
