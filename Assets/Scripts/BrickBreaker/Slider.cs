using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public Vector2 bounds;
    public float speed;
    public GameObject leftBound;
    public GameObject rightBound;

    private float objectBounds;

    void Start()
    {
        objectBounds = transform.GetComponent<MeshRenderer>().bounds.extents.x // get half slider width
            + leftBound.transform.GetComponent<MeshRenderer>().bounds.extents.x; // get half wall width
        Debug.Log(objectBounds);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, 0.0f);
        //Debug.Log("movement " + movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, rightBound.transform.position.x + objectBounds, leftBound.transform.position.x - objectBounds); ;
        transform.position = viewPos;
    }
}
