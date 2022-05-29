using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI count;
    public LoadScenes loadScenes;

    void Start()
    {
        StartCoroutine(counter());
    }

    public IEnumerator counter()
    {
        count.text = "5";
        yield return new WaitForSeconds(1f);

        count.text = "4";
        yield return new WaitForSeconds(1f);

        count.text = "3";
        yield return new WaitForSeconds(1f);

        count.text = "2";
        yield return new WaitForSeconds(1f);

        count.text = "1";
        yield return new WaitForSeconds(1f);

        count.text = "0";
        yield return new WaitForSeconds(1f);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ReadyPlayer1"))
        {
            loadScenes.LoadGameButterfly();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ReadyPlayer2"))
        {
            loadScenes.LoadGameBee();
        }
    }
}
