using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ScoreBee;
    public static int ScoreButterfly;
    public TextMeshProUGUI textScoreBee;
    public TextMeshProUGUI textScoreButterfly;

    public void upScoreByOne(string playerName)
    {
        if(playerName == "Bee")
        {
            ScoreBee++;
            textScoreBee.text = ScoreBee.ToString();
        }
        if(playerName == "Butterfly")
        {
            ScoreButterfly++;
            textScoreButterfly.text = ScoreButterfly.ToString();
        }
    }

    public void upScoreByTwo(string playerName)
    {
        if (playerName == "Bee")
        {
            ScoreBee += 2;
            textScoreBee.text = ScoreBee.ToString();
        }
        if (playerName == "Butterfly")
        {
            ScoreButterfly += 2;
            textScoreButterfly.text = ScoreButterfly.ToString();
        }
    }
}
