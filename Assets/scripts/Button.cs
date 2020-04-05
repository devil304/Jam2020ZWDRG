using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] float delayTime;
    public void loadScene(string sceneName)
    {
        StartCoroutine(ChangeScene(delayTime,sceneName));
    }

    IEnumerator ChangeScene(float delay, string name){
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.allowSceneActivation = false;
        yield return new WaitForSeconds(delay);
        ao.allowSceneActivation = true;
    }
    
    public void exitGame()
    {
        Application.Quit();
    }
}
