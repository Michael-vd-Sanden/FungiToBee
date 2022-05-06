using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stage = 0;
    [SerializeField] private int startingStage;

    public void Start()
    {
        stage = startingStage;
    }

    public void SetStage(int newStage)
    {
        stage = newStage;
    }

    public int GetStage()
    {
        return this.stage;
    }
}
