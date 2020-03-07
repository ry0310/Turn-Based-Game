using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) // Checks for collision
    {
        if (col.gameObject.CompareTag("Player")) // Checks if the player collided with this object
        {
            SceneManager.UnloadSceneAsync("TutorialLevel"); // If so, unlaod tutoriallevel and enable combat as a single SceneMode
            SceneManager.LoadScene("Combat", LoadSceneMode.Single);
        }
    }
}
