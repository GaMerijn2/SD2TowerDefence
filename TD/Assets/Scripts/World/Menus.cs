using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] private bool invokeBool = true;
    [SerializeField] private float timeSpeed = 9;
    
    public void PauseGame()
    {
        for (int i = 0; i < timeSpeed; i++)
        {
            Time.timeScale -= 0.1f;
            Debug.Log(Time.timeScale);
            if (Time.timeScale <= 0.1)
            {
                Time.timeScale = 0;
            }
        }
    }
    public void ResumeGame()
    {
        for (int i = 0; i < timeSpeed; i++)
        {
            Time.timeScale += 0.1f;
            Debug.Log(Time.timeScale);
            if (Time.timeScale >= 1)
            {
                Time.timeScale = 1;
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
