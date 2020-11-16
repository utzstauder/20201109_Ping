using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    readyToPlay     = 0,
    playing         = 1,
    gameOver        = 2
}

public class ScoreController : MonoBehaviour
{
    int scorePlayer1;
    int scorePlayer2;

    GameState currentState;

    public int scoreToWin = 5;

    public Text scorePlayer1Text;
    public Text scorePlayer2Text;
    public Text startText;

    public BallController ball;

    void ResetScore()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateUI();
    }

    private void Start()
    {
        currentState = GameState.readyToPlay;
        startText.enabled = true;

        ResetScore();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (currentState == GameState.readyToPlay)
            {
                // launch ball
                ball.StartBall();

                startText.enabled = false;

                currentState = GameState.playing;
            } else if (currentState == GameState.gameOver)
            {
                // TODO: hide winner UI

                ResetScore();
                startText.enabled = true;
                currentState = GameState.readyToPlay;
            }
        }
    }

    void EvaluateWinCondition()
    {
        if (scorePlayer1 >= scoreToWin || scorePlayer2 >= scoreToWin)
        {
            // stop ball
            ball.StopAndResetBall();

            if (scorePlayer1 > scorePlayer2)
            {
                // winner: P1
                scorePlayer1Text.text += "\n WINNER";
            } else
            {
                // winner: P2
                scorePlayer2Text.text += "\n WINNER";
            }

            currentState = GameState.gameOver;
        }
    }

    void UpdateUI()
    {
        scorePlayer1Text.text = scorePlayer1.ToString();
        scorePlayer2Text.text = scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        scorePlayer1++;
        UpdateUI();
        EvaluateWinCondition();
    }

    public void GoalPlayer2()
    {
        scorePlayer2++;
        UpdateUI();
        EvaluateWinCondition();
    }
}
