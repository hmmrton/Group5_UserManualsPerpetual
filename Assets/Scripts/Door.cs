using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    bool doorOpen;

    Vector3 doorRotation; // rotation for the door to be open
    // rotation for door being closed is zero vector
    // Start is called before the first frame update
    void Start()
    {
        doorRotation = new Vector3(0, -50, 0);
        doorOpen = false;
    }

    public bool isDoorOpen()
    {
        return doorOpen;
    }
    public void openDoor()
    {
        if (!doorOpen)
        {
            door.transform.eulerAngles = doorRotation;
            doorOpen = true;
        }
    }
    public void closeDoor()
    {
        if (doorOpen)
        {

            door.transform.eulerAngles = Vector3.zero;
            doorOpen = false;
        }
    }
}
