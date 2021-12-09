using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossGameOver;
    public Camera officeCam;
    private Vector3 bossPosConstVector;
    private Vector3 bossPosConstVector2;
    private bool caught;
    void Start()
    {
        caught = false;
        bossPosConstVector = new Vector3(10.79f, 2.79f, 57.15f);
        bossPosConstVector2 = new Vector3(-1.489339f, 2.79f, 57.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!caught) {
            if (BossMoveDebug.doorCheck && ComputerFocusCamera.zoomed) 
            {
                ComputerFocusCamera.requestToToggleZoom = true;
                officeCam.transform.position = new Vector3(0, 2, 30);
                Debug.Log("unzoom requested");
                caught = true;
                boss.SetActive(false);
                bossGameOver.SetActive(true);
                StartCoroutine(DelayAndSetCaught());
            } // this is for when opening door
            /*else if (boss.transform.position == bossPosConstVector2
                && boss.transform.localScale == Vector3.zero
                && ComputerFocusCamera.zoomed
            ) {
                ComputerFocusCamera.requestToToggleZoom = true;
                officeCam.transform.position = new Vector3(0, 2, 30);
                Debug.Log("unzoom requested");
                caught = true;
                boss.SetActive(false);
                bossGameOver.SetActive(true);
                StartCoroutine(DelayAndSetCaught());
            }*/ // this is for when looking in window.
        }
    }

    private IEnumerator DelayAndSetCaught()
    {
        yield return new WaitForSecondsRealtime(4);
        GameManagerOffice.caught = true;
    }
}
