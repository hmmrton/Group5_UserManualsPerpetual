using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DesktopIcon : MonoBehaviour
{
    Button button;
    public GameObject BrickBreaker;
    public GameObject Pong;

    public static bool BrickBreakerDisable;
    public static bool PongDisable;

    private void Start()
    {
        BrickBreakerDisable = false;
        PongDisable = false;
    }

    void Update()
    {
        if (BrickBreakerDisable)
        {
            BrickBreakerDisable = false;
            BrickBreaker.SetActive(false);
        }
        if (PongDisable)
        {
            PongDisable = false;
            Pong.SetActive(false);
        }
    }

    public void handleBrickBreakerButtonClicked()
    {
        BrickBreaker.SetActive(true);
    }
    public void handlePongButtonClicked()
    {
        Pong.SetActive(true);
    }
}
