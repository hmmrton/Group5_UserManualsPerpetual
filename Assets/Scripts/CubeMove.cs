using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public GameObject cube;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        x += 0.0001f;
        cube.transform.Rotate(x, x, x);
    }
}
