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

    private void Start()
    {
        pongUI.SetActive(true);
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "" + GoalPong.playerScore;
        aiScoreText.text = "" + GoalPong.aiScore;
    }

    public void resetGame()
    {
        if (currentBall != null)
            Destroy(currentBall);
        currentBall = Instantiate(ballPrefab);
    }
}
