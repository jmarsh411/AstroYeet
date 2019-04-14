using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            MainMenu();
        }
        else if (Input.anyKey)
        {
            //MainMenu();
            Restart();
        }


    }

    private void Quit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
