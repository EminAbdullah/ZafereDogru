using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public GameObject finishPoint;
    public GameObject finishPanel;
    public GameObject pausePanel;
    public TMP_Text puanText;
    public TMP_Text puanTextFinish;
    public TMP_Text finishText;
    public float puan=2;

    public GameObject spawnerTop;
    public GameObject spawnerBottom;
    public GameObject spawnerRight;
    public GameObject spawnerLeft;
    public string restartLevelName;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        puanText.text = ((int)puan).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       // SpawnPos();
        puan -= Time.deltaTime;
        puanText.text = ((int)puan).ToString();
        if (finishPanel.gameObject.activeSelf ==false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
            

    }

    public void PauseGame()
    {

        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
           


    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(restartLevelName);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SpawnPos()
    {
        if (player !=null)
        {
            if (player.gameObject.transform.position.x < -53)
            {
                spawnerLeft.gameObject.SetActive(false);
                spawnerRight.gameObject.GetComponent<EnemySpawner>().spawnRate = 1.5f;
            }
            else
            {

                spawnerLeft.gameObject.SetActive(true);
                spawnerRight.gameObject.GetComponent<EnemySpawner>().spawnRate = 3f;
            }
            if (player.gameObject.transform.position.x > 52)
            {
                spawnerRight.gameObject.SetActive(false);
                spawnerLeft.gameObject.GetComponent<EnemySpawner>().spawnRate = 1.5f;
            }
            else
            {

                spawnerRight.gameObject.SetActive(true);
                spawnerLeft.gameObject.GetComponent<EnemySpawner>().spawnRate = 3f;
            }

            if (player.gameObject.transform.position.y < -57)
            {
                spawnerBottom.gameObject.SetActive(false);
                spawnerTop.gameObject.GetComponent<EnemySpawner>().spawnRate = 1.5f;
            }
            else
            {

                spawnerBottom.gameObject.SetActive(true);
                spawnerTop.gameObject.GetComponent<EnemySpawner>().spawnRate = 3f;
            }


            if (player.gameObject.transform.position.y > 57)
            {
                spawnerTop.gameObject.SetActive(false);
                spawnerBottom.gameObject.GetComponent<EnemySpawner>().spawnRate = 1.5f;
            }
            else
            {

                spawnerTop.gameObject.SetActive(true);
                spawnerBottom.gameObject.GetComponent<EnemySpawner>().spawnRate = 3f;
            }
        }
       
    }

}
