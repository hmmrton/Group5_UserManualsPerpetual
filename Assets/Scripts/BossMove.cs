using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public bool bossWalkVisible;
    public bool bossLookVisible;
    Vector3 startPos;
    Vector3 doorPos;
    Vector3 lookPos;
    int movementPattern;
    /**
     * pattern 0 = resting state
     * pattern 1 = moving to lookPos
     * pattern 2 = at look lookPos
     * pattern 3 = moving to doorPos
     * pattern 4 = at doorPos
     * pattern 5 = resetting to resting state
    */
    public int speed;
    float counter;
    bool counting;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(-15f, 3f, 56f);
        doorPos = new Vector3(7.5f, 2.5f, 45f);
        lookPos = new Vector3(0, 2.5f, 46f);
        movementPattern = 0;
        counting = false;
        counter = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( counting && counter > 5f)
        {
            counter = 0;
            counting = false;
        }
        else if (counting)
        {
            counter += Time.deltaTime;
        }
        else
        {

        }
    }

    private void waitSeconds(float seconds)
    {
        timer = seconds;
        counting = true;
    }
}
