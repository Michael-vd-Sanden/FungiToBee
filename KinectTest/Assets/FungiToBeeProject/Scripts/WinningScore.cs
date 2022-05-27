using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningScore : MonoBehaviour
{
    public TextMeshProUGUI textScoreBee;
    public TextMeshProUGUI textScoreButterfly;

    public void Start()
    {
        GetPoints();
    }

    public void GetPoints()
    {
        int beePoints = Score.ScoreBee;
        textScoreBee.text = beePoints.ToString();

        int butterflyPoints = Score.ScoreButterfly;
        textScoreButterfly.text = butterflyPoints.ToString();
    }
}
