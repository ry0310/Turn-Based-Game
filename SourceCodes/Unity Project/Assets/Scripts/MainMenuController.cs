using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string sceneName, sceneName2;

    public void StartGame() // Attached to the player button
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single); //Load 2 scenes, 1 as single and 1 as additive
        SceneManager.LoadScene(sceneName2, LoadSceneMode.Additive);
    }

    public void ExitGame() // Attached to the exit game button
    {
        Application.Quit();
    }
}