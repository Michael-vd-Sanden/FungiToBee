using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            loadScenes.LoadMainScene();
            Score.ScoreBee = 0;
            Score.ScoreButterfly = 0;
        }
    }

    void OnCollisionExit()
    {
        collided = false;
    }
}
