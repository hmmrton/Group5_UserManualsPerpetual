using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
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
    public bool gameComplete;
    List<GameObject> bricks;
    GameObject currentBrickSet;
    GameObject currentBall;
    GameObject currentSlider; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playing = false;
        gameComplete = false;
        menu = true;
        PlayMenu.SetActive(true);
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
                LossMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (bricks.Count == 0)
            {
                win = true;
                loss = false;
                menu = true;
                playing = false;
                WinMenu.SetActive(true);
                Time.timeScale = 0;
            }
            Debug.Log(bricks.Count);
            bricks = bricks.Where(b => b != null).ToList();
        }
    }

    public void handlePlayButtonClicked()
    {
        SetupGame();
        PlayMenu.SetActive(false);
        Time.timeScale = 1;
        playing = true;
        menu = false;
    }

    public void handleRetryButtonClicked()
    {
        // need to reset ball
        Debug.Log("trying retry1");
        Destroy(currentBrickSet);
        Destroy(currentBall);
        Destroy(currentSlider);
        BottomWall.ballHitBottom = false;
        SetupGame();
        LossMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("trying retry2");
        playing = true;
        menu = false;
    }

    public void handleQuitButtonClicked()
    {
        gameComplete = true;
    }
}
