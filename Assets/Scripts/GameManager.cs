using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Scene management
    private Scene scene;
    private Counter counter;
    private int time = 15;
    private int firstSceneIndex = 1;
    public bool isGameActive;

    // User Interface
    public Button restartButton;
    public Button startButton;
    public Text levelText;
    public Text gameOverText;
    public Text timeText;
    public Text gameName;

    public AudioSource gameOverSound;
    public AudioSource startSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
        isGameActive = true;
        startSound.Play();

        counter = FindObjectOfType<Counter>();

        scene = SceneManager.GetActiveScene();
        levelText.text = "Level: " + (scene.buildIndex);

    }

    // Update is called once per frame
    void Update()
    {
        RestartScene();
        LoadNextScene();
    }

    // Countdown from 15 to 0
    IEnumerator CountDown()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            while (time > 0)
            {
                yield return new WaitForSeconds(1);
                time--;
                timeText.text = "Time: " + time;
            }
            GameOver();
        }
    }

    // Restart the scene if the player fails to score
    void RestartScene()
    {
        if (FindObjectOfType<PlayerController>().playerJumped && !counter.CheckIfScored()
            && FindObjectOfType<PlayerController>().hasGrounded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Load the next scene if player scores
    void LoadNextScene()
    {
        if (FindObjectOfType<PlayerController>().playerJumped && counter.CheckIfScored()
            && FindObjectOfType<PlayerController>().hasGrounded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Stops the game and shows Game Over text with Restart button
    void GameOver()
    {
        isGameActive = false;
        gameOverSound.Play();
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    // Starts the game from scene 1
    public void StartGame()
    {
        isGameActive = true;
        SceneManager.LoadScene(firstSceneIndex);
        startButton.gameObject.SetActive(false);
        gameName.gameObject.SetActive(false);

    }

    // Loads the main/start menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        isGameActive = false;
    }
}
