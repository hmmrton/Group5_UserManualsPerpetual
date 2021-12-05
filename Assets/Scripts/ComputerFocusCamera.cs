using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerFocusCamera : MonoBehaviour
{
    // Unzoomed:
    // position x -> 0 y -> 2 z -> 30
    float unzoomedPosY = 2.0f;
    float unzoomedPosZ = 30.0f;
    // Zoomed:
    // position x -> 0 y -> 1.75 z -> 31
    float zoomedPosY = 1.75f;
    float zoomedPosZ = 31.6f;

    bool zoomed;
    bool zooming;
    bool zoomEnabled;
    float nextZoom = 0.0f;
    public float duration = 1.0f;

    public Camera officeCam;
    public Camera gameCam;

    private void Start()
    {
        zoomed = false;
        zooming = false;
        zoomEnabled = true;

        officeCam.enabled = true;
        gameCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (zooming)
        {
            //Debug.Log(zoomed ? "unfocusing" : "focusing");
            //Debug.Log("zoomEnabled? " + zoomEnabled);
            //Debug.Log("updates: " + nextZoom);
            ZoomCamera();
        }
        if ((zoomEnabled && Input.GetAxis("FocusUnfocus") > 0))
        {
            //Debug.Log("zoomin");
            nextZoom = Time.time + duration;
            zoomEnabled = false;
            zooming = true;
        }
    }

    void ZoomCamera()
    {
        //Debug.Log("next " + nextZoom + " time time " + Time.time + " zoomin " + zooming);
        if (nextZoom < Time.time)
        {
            StopZooming();
            return;
        }
        if (zoomed)
        {
            gameObject.transform.position = Vector3.Lerp(       
                new Vector3(0, unzoomedPosY, unzoomedPosZ),
                gameObject.transform.position,
                Time.time / nextZoom
            );
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(
                new Vector3(0, zoomedPosY, zoomedPosZ),
                gameObject.transform.position,
                Time.time / nextZoom
            );
        }
    }

    void StopZooming()
    {
 
        if (!officeCam.enabled)
        {
            Debug.Log("swapping to office cam");
            officeCam.enabled = true;
            gameCam.enabled = false;
        }
        else
        {
            Debug.Log("trying to swap to game cam");
            gameCam.enabled = true;
            officeCam.enabled = false;
        }

        zoomed = !zoomed;
        gameObject.transform.position = zoomed ? new Vector3(0, zoomedPosY, zoomedPosZ) : new Vector3(0, unzoomedPosY, unzoomedPosZ);
        zooming = false;
        zoomEnabled = true;
    }
}
