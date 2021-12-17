using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPong : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (ComputerFocusCamera.zoomed) // can only affect player paddle if zoomed in
        {
            if (gameObject.transform.position.y < 4 && gameObject.transform.position.y > -4
            || gameObject.transform.position.y >= 4 && Input.GetAxis("Vertical") < 0
            || gameObject.transform.position.y <= -4 && Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
            }
        }
    }
}
