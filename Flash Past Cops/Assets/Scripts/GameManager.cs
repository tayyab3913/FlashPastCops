using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] panels;
    public Text scoreText;
    int score;
    public Text lifeText;
    public bool gameOver;
    public GameObject pauseScreen;

    public int health = 10;
    public GameObject player;

    public int collectables = 0;
    public int collectablesToWin = 5;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        ActivePanel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCollectable()
    {
        collectables++;
        UpdateScore(collectables);
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        UpdateLife(health);
        CheckDeath();
    }

    void CheckDeath()
    {
        if(health < 1)
        {
            Debug.Log("Player Died");
            Destroy(gameObject);
        }
    }

    public void SetTimeSlowMotion()
    {
        Time.timeScale = 0.2f;
    }

    public void SetTimeNormal()
    {
        Time.timeScale = 1f;
    }

    public void ActivePanel(int panelIndex)
    {
        DeavtivePanels();
        panels[panelIndex].SetActive(true);
    }
    void DeavtivePanels()
    {
        foreach (GameObject panel in panels)
            panel.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        ActivePanel(4);
        Time.timeScale = 0;
    }

 
     void UpdateScore(int scoreToUpdate)
    {
        scoreText.text = "Score:" + score.ToString();
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScore(score);
    }

    void UpdateLife(int lifeToUpdate)
    {
        lifeText.text = "Health: " + health.ToString();
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        gameOver = false;
        ActivePanel(3);
        UpdateScore(0);
    }
}
