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
    void Update()
    {
        if (caught)
        {
            SceneManager.LoadScene("LossScene");
        }
        else if (brickBreakerComplete && pongComplete)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
