using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Menus : MonoBehaviour
{
    //public TextMeshProUGUI playerScoreText;
    //public TextMeshProUGUI enemyScoreText;

    //public AudioClip blink;
    //public AudioSource soundsUI;

    //public GameObject cataloguePopup;
    public bool gameIsPaused = false;
    public Canvas pauseMenu;
    public Canvas mainMenu;
    public Canvas credits;

    InputAction pauseKey;

    public static Menus instance;
    void Awake()
    {
        //for making this a singleton
        if (instance == null)
        {
            instance = this;
        }

        credits.enabled = false;
        pauseKey = InputSystem.actions.FindAction("Pause");
        PauseGame();
    }

    void Update()
    {
        if (pauseKey.WasPerformedThisFrame())
        {
            PauseGame();
            playButtonSound();
            Debug.Log("pressed pause key");
        }
    }    

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        mainMenu.enabled = true;
        CustomerSystem.instance.waveCount = 0;
    }

    public void Retry()
    {
        //gets the build number of the current level and reloads that
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        //closes game
        Application.Quit();
    }

    public void StartGame()
    {
        EnemySpawner.instance.StartSpawn();
        mainMenu.enabled = false;
        CustomerSystem.instance.waveCount = 0;  
        Resume();
    }

    public void playButtonSound()
    {
        //use this function to play sounds for everything in the ui
       // soundsUI.PlayOneShot(blink);
    }

    public void PauseGame()
    {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                pauseMenu.enabled = true;
                Time.timeScale = 0f;
                gameIsPaused = true;
                Debug.Log("Game is paused");
            }
    }

    public void Resume()
    {
        if (gameIsPaused)
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1f;
            gameIsPaused = false;
            Debug.Log("Game is resumed");
        }
    }

    public void Credits()
    {
        if (credits.enabled)
        {
            credits.enabled = false;
        }
        else
        {
            credits.enabled = true;
        }
    }
}
