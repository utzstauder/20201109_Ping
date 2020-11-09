using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int scorePlayer1;
    int scorePlayer2;

    public int scoreToWin = 5;

    public Text scorePlayer1Text;
    public Text scorePlayer2Text;

    void ResetScore()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateUI();
    }

    private void Start()
    {
        ResetScore();
    }

    void EvaluateWinCondition()
    {
        if (scorePlayer1 >= scoreToWin || scorePlayer2 >= scoreToWin)
        {
            // Game over

            if (scorePlayer1 > scorePlayer2)
            {
                // winner: P1

            } else
            {
                // winner: P2

            }

            // reset game
            ResetScore();
            // TODO: reset ball
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
        EvaluateWinCondition();
        UpdateUI();
    }

    public void GoalPlayer2()
    {
        scorePlayer2++;
        EvaluateWinCondition();
        UpdateUI();
    }
}
