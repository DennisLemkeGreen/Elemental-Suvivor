using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Start the game
    public void Play()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    // Close the game
    public void Quit()
    {
        /*
        // In Unity Editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        */

        // In real game
        Application.Quit();
    }
}
