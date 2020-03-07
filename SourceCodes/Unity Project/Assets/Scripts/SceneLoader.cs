using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneToLoad;
    public string SceneToUnload;

    public Animator transition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if the player collided with this object
        {
            StartCoroutine("LoadLevel"); // start the coroutine for next level
        }
    }

    private void Start()
    {
        transition.SetTrigger("End"); // Sets the animation for fading between scene to End when scene starts
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start"); // Sets the animation to starts
        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync(SceneToUnload); // After 1 second, scene according to the SceneToUnload string and loads the SceneToLoad as an additive, to preserve the DataManagement scene
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
    }
}
