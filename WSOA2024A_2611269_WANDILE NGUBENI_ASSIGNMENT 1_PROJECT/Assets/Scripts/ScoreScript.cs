
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

    public TextMeshProUGUI AiScoreTxt, PlayerScoreTxt;

    public UiManager uiManager;

    public int maxScore;

    //Scores
    private int aiScore, playerScore;

    private int AiScore
    {
        get { return aiScore; }
        set
        { 
            aiScore = value;
            if (value == maxScore )
                uiManager.ShowRestartCanvas(true);
        }
    }
    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == maxScore)
                uiManager.ShowRestartCanvas(false);
        }
    }
    //Scores


    public void Increment(Score whichever)
    {
        if(whichever == Score.AiScore)
         AiScoreTxt.text = (++AiScore).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }

    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }
    
}
