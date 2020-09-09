using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public static GameObject activeScene;

    public void NextLevel()
    {
        Debug.Log("Pitää muuttaa että ottaa huomioon läpäistyn levelin scene indexin ja lisää siihen");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Menu");
    }
}
