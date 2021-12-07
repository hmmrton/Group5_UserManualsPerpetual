using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPong : MonoBehaviour
{
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
