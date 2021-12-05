using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{

    bool inScreen;
    public GameObject redWall;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        inScreen = false;
        redWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            if (!inScreen)
                inScreen = true;
            else
                inScreen = false;
        }

        if (boss.transform.position == new Vector3(10.79f, 2.79f, 57.15f) && inScreen) 
        {
            redWall.SetActive(true);
        }
        else if(boss.transform.position == new Vector3(-1.489339f, 2.79f, 57.15f) && boss.transform.localScale == new Vector3(0, 0, 0) && inScreen)
        {
            redWall.SetActive(true);
        }
    }
}
