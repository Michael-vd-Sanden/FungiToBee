using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    bool collided;
    private LoadScenes loadScenes;
    [SerializeField] private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        loadScenes = gameManager.GetComponent<LoadScenes>();
    }

    IEnumerator OnTriggerEnter(Collider collider)
    {
        collided = true;
        yield return new WaitForSeconds(3);
        if (collided)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartingScreen"))
            {
                loadScenes.LoadExplanationScene();
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ExplanationScene"))
            {
                loadScenes.LoadPlayer1();
                Score.ScoreTileBee = 0;
                Score.ScoreTileButterfly = 0;
            }  
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ScoreScene"))
            {
                loadScenes.LoadStartScreen();
            }
        }
    }

    void OnCollisionExit()
    {
        collided = false;
    }
}
