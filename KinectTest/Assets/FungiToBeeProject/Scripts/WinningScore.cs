using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningScore : MonoBehaviour
{
    public TextMeshProUGUI textScoreBee;
    public TextMeshProUGUI textScoreButterfly;

    [SerializeField] private TextMeshProUGUI BeeFirstMinute;
    [SerializeField] private TextMeshProUGUI BeeSecondMinute;
    [SerializeField] private TextMeshProUGUI BeeFirstSecond;
    [SerializeField] private TextMeshProUGUI BeeSecondSecond;

    [SerializeField] private TextMeshProUGUI ButterflyFirstMinute;
    [SerializeField] private TextMeshProUGUI ButterflySecondMinute;
    [SerializeField] private TextMeshProUGUI ButterflyFirstSecond;
    [SerializeField] private TextMeshProUGUI ButterflySecondSecond;

    public void Start()
    {
        GetPoints();
    }

    public void GetPoints()
    {
        int beePoints = Score.ScoreTileBee;
        textScoreBee.text = beePoints.ToString();

        int butterflyPoints = Score.ScoreTileButterfly;
        textScoreButterfly.text = butterflyPoints.ToString();

        float beeTime = Score.ScoreTimeBee;
        updateBeeTimerDisplay(beeTime);

        float butterflyTime = Score.ScoreTimeButterfly;
        updateButterflyTimerDisplay(butterflyTime);
    }

    public void updateBeeTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        BeeFirstMinute.text = currentTime[0].ToString();
        BeeSecondMinute.text = currentTime[1].ToString();
        BeeFirstSecond.text = currentTime[2].ToString();
        BeeSecondSecond.text = currentTime[3].ToString();
    }

    public void updateButterflyTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        ButterflyFirstMinute.text = currentTime[0].ToString();
        ButterflySecondMinute.text = currentTime[1].ToString();
        ButterflyFirstSecond.text = currentTime[2].ToString();
        ButterflySecondSecond.text = currentTime[3].ToString();
    }
}
