using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wincondition : MonoBehaviour
{
    public List<HexagonChange> hexagons;
    private LoadScenes loadScenes;

    private void Awake()
    {
        loadScenes = GetComponent<LoadScenes>();
    }

    private void Update()
    {
        if (CheckIfGreen())
        {
            Debug.Log("WON!");
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameBee"))
            {
                loadScenes.LoadScoreScene();
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameButterfly"))
            {
                loadScenes.LoadPlayer2();
            }
        }
        if (CheckIfDead())
        {
            Debug.Log("LOST");
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameBee"))
            {
                Score.ScoreBee = 0;
                loadScenes.LoadScoreScene();
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameButterfly"))
            {
                Score.ScoreButterfly = 0;
                loadScenes.LoadPlayer2();
            }
        }
    }

    public bool CheckIfGreen()
    {
        foreach(HexagonChange h in hexagons)
        {
            if (h.GetisGreen() == false)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckIfDead()
    {
        foreach (HexagonChange h in hexagons)
        {
            if (h.GetisDead() == false)
            {
                return false;
            }
        }
        return true;
    }
}
