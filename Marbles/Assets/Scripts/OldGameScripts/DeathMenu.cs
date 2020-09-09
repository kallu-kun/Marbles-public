using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public void Restart()
    {   
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restarted Scene");
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Menu");
    }
}
