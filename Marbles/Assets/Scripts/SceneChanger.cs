
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
