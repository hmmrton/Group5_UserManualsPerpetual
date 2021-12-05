using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 cameraObject;
    bool isZoom;

    public Transform Trans;
    public float CamMoveSpeed = 5.0f;

    void Start()
    {
        isZoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            if (!isZoom)
            {
                cameraObject = new Vector3(0f, 1.7f, 31.24f);
                isZoom = true;
            }
            else 
            {
                cameraObject = new Vector3(0f, 2f, 30f);
                isZoom = false;
            }

            Trans.position = Vector3.Lerp(Trans.position, cameraObject, CamMoveSpeed * Time.deltaTime);
        }
    }
}
