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

    public void LoadPlayer1()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("ReadyPlayer1");
    }

    public void LoadPlayer2()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("ReadyPlayer2");
    }

    public void LoadGameBee()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("GameBee");
    }

    public void LoadGameButterfly()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("GameButterfly");
    }

    public void LoadScoreScene()
    {
        main.transform.SetParent(cameraParent.transform);
        SceneManager.LoadScene("ScoreScene");
    }

    public void ExitProgram()
    {
        Application.Quit();
        Debug.Log("I quit!");
    }
}
