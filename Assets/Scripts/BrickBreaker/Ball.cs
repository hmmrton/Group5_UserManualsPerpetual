using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody rigidBody;
    public float xStartForce;
    public float yStartForce;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody>();
        this.rigidBody.AddForce(new Vector3(xStartForce, yStartForce, 0.0f), ForceMode.Impulse);
    }
}
