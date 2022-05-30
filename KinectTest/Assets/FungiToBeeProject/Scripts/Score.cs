using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int ScoreTileBee;
    public static int ScoreTileButterfly;
    public static float ScoreTimeBee;
    public static float ScoreTimeButterfly;
    public TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI SecondSecond;

    private float timer;
    private bool isButterfly = true;

    private void Start()
    {
        whichLevel();
        resetTimer();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        updateTimerDisplay(timer);
        if (isButterfly)
        { ScoreTimeButterfly = timer; }
        else
        { ScoreTimeBee = timer;  }
    }

    private void whichLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameButterfly"))
        {
            isButterfly = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameBee"))
        {
            isButterfly = false;
        }
    }

    public void upScoreByOne(string playerName)
    {
        if(playerName == "Bee")
        {
            ScoreTileBee++;
            textScore.text = ScoreTileBee.ToString();
        }
        if(playerName == "Butterfly")
        {
            ScoreTileButterfly++;
            textScore.text = ScoreTileButterfly.ToString();
        }
    }

    public void upScoreByTwo(string playerName)
    {
        if (playerName == "Bee")
        {
            ScoreTileBee += 2;
            textScore.text = ScoreTileBee.ToString();
        }
        if (playerName == "Butterfly")
        {
            ScoreTileButterfly += 2;
            textScore.text = ScoreTileButterfly.ToString();
        }
    }

    public void resetTimer()
    {
        timer = 0;
    }

    public void updateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        SecondSecond.text = currentTime[3].ToString();
    }
}
