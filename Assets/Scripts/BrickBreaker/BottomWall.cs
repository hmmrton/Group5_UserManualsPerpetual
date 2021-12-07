using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    public static bool ballHitBottom = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BrickBreakerBall")
        {
            ballHitBottom = true;
        }
    }
}
