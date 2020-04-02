using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void exitGame()
    {
        Application.Quit();
    }
}
