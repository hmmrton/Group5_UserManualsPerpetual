using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerPong : MonoBehaviour
{
    public Text playerScoreText;
    public Text aiScoreText;
    public GameObject ballPrefab;
    public static GameObject currentBall;
    public GameObject pongUI;

    int delayCounter;
    public int delay;

    private void Start()
    {
        pongUI.SetActive(true);
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (delayCounter >= delay)
        {
            GoalPong.playerScore = 0;
            GoalPong.aiScore = 0; // reset
            DesktopIcon.PongDisable = true;
        }
        else if (GoalPong.playerScore >= 10 || GoalPong.aiScore >= 10)
        {
            delayCounter++;
        }
        else
        {
            playerScoreText.text = "" + GoalPong.playerScore;
            aiScoreText.text = "" + GoalPong.aiScore;
        }
    }

    public void resetGame()
    {
        if (currentBall != null)
            Destroy(currentBall);
        if (GoalPong.playerScore >= 10)
        {
            playerScoreText.text = "You Win!";
            aiScoreText.text = "" + GoalPong.playerScore + " - " + GoalPong.aiScore;
            Debug.Log("Won");
            GameManagerOffice.pongComplete = true;
        }
        else if (GoalPong.aiScore >= 10)
        {
            playerScoreText.text = "You Lose!";
            aiScoreText.text = "" + GoalPong.playerScore + " - " + GoalPong.aiScore;
        }
        else
        {
            
            currentBall = Instantiate(ballPrefab);
        }
    }
}
