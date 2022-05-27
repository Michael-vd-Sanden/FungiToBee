using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public Camera main;
    public GameObject cameraParent;

    public void LoadStartScreen()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("StartingScreen");
    }

    public void LoadExplanationScene()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("ExplanationScene");
    }

    public void LoadMainScene()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("MainScene");
    }

    public void ExitProgram()
    {
        Application.Quit();
        Debug.Log("I quit!");
    }
}
