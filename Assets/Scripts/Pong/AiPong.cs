using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPong : MonoBehaviour
{
    public float speed = 5f;
    public static GameObject ball;

    // Update is called once per frame
    void Update()
    {
        ball = GameManagerPong.currentBall;
        if (ball != null)
        {
            if (gameObject.transform.position.y < 4 && gameObject.transform.position.y > -4
            || gameObject.transform.position.y >= 4 && Input.GetAxis("Vertical") < 0
            || gameObject.transform.position.y <= -4 && Input.GetAxis("Vertical") > 0)
            {
                float dir = 0;
                if (ball.transform.position.y > gameObject.transform.position.y - 1.5f)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;
                }
                transform.Translate(0f, dir * speed * Time.deltaTime, 0f);
            }
            // this script down here is way to fucking strong. p sure it cant lose cause of speeds
            /*float dir = 0;
            if (ball.transform.position.y > gameObject.transform.position.y)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
            gameObject.transform.Translate(0f, dir * speed * Time.deltaTime, 0f);*/
        }
    }
}
