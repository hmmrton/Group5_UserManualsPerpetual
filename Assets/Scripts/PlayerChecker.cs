using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public GameObject boss;
    private Vector3 bossPosConstVector;
    private Vector3 bossPosConstVector2;
    void Start()
    {
        bossPosConstVector = new Vector3(10.79f, 2.79f, 57.15f);
        bossPosConstVector2 = new Vector3(-1.489339f, 2.79f, 57.15f);
    }

    // Update is called once per frame
    void Update()
    {


        if (boss.transform.position == bossPosConstVector && ComputerFocusCamera.zoomed) 
        {
            GameManagerOffice.caught = true;
        }
        else if (boss.transform.position == bossPosConstVector2
            && boss.transform.localScale == Vector3.zero
            && ComputerFocusCamera.zoomed
        ) {
            GameManagerOffice.caught = true;
        }
    }
}
