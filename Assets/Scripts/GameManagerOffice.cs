using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerOffice : MonoBehaviour
{
    public static bool caught = false;
    public static bool brickBreakerComplete = false;
    public static bool pongComplete = false;

    // Update is called once per frame

    private void Start()
    {
        caught = false;
        brickBreakerComplete = false;
        pongComplete = false; // allows reset
    }

    void Update()
    {
        if (caught)
        {
            Debug.Log("player was caught");
            SceneManager.LoadScene("LossScene");
        }
        else if (brickBreakerComplete && pongComplete)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
