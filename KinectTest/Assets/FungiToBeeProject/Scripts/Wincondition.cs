using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            loadScenes.LoadStartScreen();
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
}
