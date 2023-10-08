using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gamePanel;

    public void PlayGame(string level)
    {
        SceneManager.LoadScene(level);
    }
  
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GamePanel()
    {
        if (gamePanel.activeSelf==true)
        {
            gamePanel.SetActive(false);
        }
        else
        {
            gamePanel.SetActive(true);
        }
    }
}
