using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerBrickBreaker : MonoBehaviour
{
    public bool playing = false;
    public bool menu = true;
    public bool win = false;
    public bool loss = false;
    public GameObject brickSet;
    public GameObject ball;
    public GameObject slider;
    public GameObject PlayMenu;
    public GameObject LossMenu;
    public GameObject WinMenu;
    public static bool gameComplete = false;
    List<GameObject> bricks;
    GameObject currentBrickSet;
    GameObject currentBall;
    GameObject currentSlider; 
    // Start is called before the first frame update
    void Start()
    {
        playing = false;
        menu = true;
        if (ComputerFocusCamera.zoomed)
            PlayMenu.SetActive(true);
        else
            UIManager.bbPlayMenuZoomedState = true;
        WinMenu.SetActive(false);
        LossMenu.SetActive(false);
    }

    void SetupGame()
    {
        currentBrickSet = Instantiate(brickSet);
        bricks = new List<GameObject>();
        foreach (Transform child in currentBrickSet.transform)
        {
            GameObject c = child.gameObject;
            //Debug.Log(c.tag);
            if (c.tag == "Brick")
                bricks.Add(c);
        }
        Debug.Log(bricks.Count);
        currentBall = Instantiate(ball);
        currentSlider = Instantiate(slider);
    }

    void CleanupGame()
    {
        Destroy(currentBrickSet);
        Destroy(currentBall);
        Destroy(currentSlider);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (BottomWall.ballHitBottom)
            {
                loss = true;
                win = false;
                menu = true;
                playing = false;
                if (ComputerFocusCamera.zoomed)
                    LossMenu.SetActive(true);
                else
                    UIManager.bbLossMenuZoomedState = true;
                CleanupGame();
            }
            else if (bricks.Count == 0)
            {
                win = true;
                loss = false;
                menu = true;
                playing = false;
                if (ComputerFocusCamera.zoomed)
                    WinMenu.SetActive(true);
                else
                    UIManager.bbWinMenuZoomedState = true;
                CleanupGame();
            }
            Debug.Log(bricks.Count);
            bricks = bricks.Where(b => b != null).ToList();
        }
    }

    public void handlePlayButtonClicked()
    {
        SetupGame();
        PlayMenu.SetActive(false);
        playing = true;
        menu = false;
    }

    public void handleRetryButtonClicked()
    {
        BottomWall.ballHitBottom = false;
        SetupGame();
        LossMenu.SetActive(false);
        playing = true;
        menu = false;
    }

    public void handleQuitButtonClicked()
    {
        gameComplete = true;
        GameManagerOffice.brickBreakerComplete = true;
        DesktopIcon.BrickBreakerDisable = true;
    }
}
