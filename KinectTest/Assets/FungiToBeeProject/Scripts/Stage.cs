using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stage = 0;
    [SerializeField] private int startingStage;

    public void Start()
    {
        this.stage = startingStage;
    }

    public void SetStage(int newStage)
    {
        this.stage = newStage;
    }

    public int GetStage()
    {
        return this.stage;
    }
}
