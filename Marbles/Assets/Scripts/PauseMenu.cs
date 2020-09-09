using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject pauseMenuUI;

    private PlayerInfo playerInfo;
    private GameMaster gameMaster;
    private Level9LonelySpikeBall level9LonelySpikeBall;
    private void Start()
    {
        GameIsPaused = false;
        playerInfo = FindObjectOfType<PlayerInfo>();
        gameMaster = FindObjectOfType<GameMaster>();
        level9LonelySpikeBall = FindObjectOfType<Level9LonelySpikeBall>();
        /* 
        if (level9LonelySpikeBall == null) {
            level9LonelySpikeBall = null;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("QUIT");
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        if (level9LonelySpikeBall != null) {
            level9LonelySpikeBall.SetStartingPosition();
        }
        gameMaster.lastCheckpoint = gameMaster.startCheckpoint;
        playerInfo.ResetLives();
        ScoreScript.ResetLevel();
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restarted Scene");
    }
    public void NextLevel()
    {   
        playerInfo.ResetLives();
        ScoreScript.ResetLevel();
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
