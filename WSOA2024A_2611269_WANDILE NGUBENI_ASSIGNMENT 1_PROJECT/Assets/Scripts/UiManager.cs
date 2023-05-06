using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasInGame;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")]
    public AudioManager audioManager;

    public ScoreScript scoreScript;

    public PuckScript puckScript;

    public CharacterController characterController;

    public AIBehavior aIBehavior;


    public void ShowRestartCanvas(bool hasAiWon)
    {
        Time.timeScale = 0f;

        CanvasInGame.SetActive(false);
        CanvasRestart.SetActive(true);
        if (hasAiWon)
        {
            audioManager.PlayLostGame();
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        { 
            audioManager.PlayWonGame();
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
        
    }

    public void  RestartGame()
    {
        Time.timeScale = 1;

        CanvasInGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        characterController.ResetPosition();
        aIBehavior.ResetPosition();
        
    }
}
