using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalPong : MonoBehaviour
{
    public bool isPlayerGoal;
    public static int playerScore;
    public static int aiScore;
    public GameObject GameManagerObject;
    GameManagerPong gmPong;

    private void Start()
    {
        gmPong = GameManagerObject.GetComponent<GameManagerPong>();
        playerScore = aiScore = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PongBall"))
        {
            if (isPlayerGoal) // Ai Scored
            {
                aiScore++;
            }
            else // Player Scored
            {
                playerScore++;
            }
            gmPong.resetGame();
        }
    }
}
