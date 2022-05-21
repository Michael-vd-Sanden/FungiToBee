using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("startingScene");
    }

    public void LoadExplanationScene()
    {
        SceneManager.LoadScene("ExplanationScene");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitProgram()
    {
        Application.Quit();
        Debug.Log("I quit!");
    }
}
