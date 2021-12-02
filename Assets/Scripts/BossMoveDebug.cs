using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveDebug : MonoBehaviour
{
    public bool bossDebugActive;

    private Vector3 target = new Vector3(10.79f, 2.79f, 57.15f);
    private Vector3 target1 = new Vector3(-7.79f, 2.79f, 57.15f);
    public float speed;
    private int currentPattern;
    public GameObject door;
    private int directionMove;


    void Start() 
    {
        StartCoroutine(doorClose());
 
        door.transform.eulerAngles = new Vector3(0, 0, 0);
        directionMove = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1")) 
        {
            currentPattern = 1;
            Debug.Log("Inititating Pattern One");
        }

        if (bossDebugActive && currentPattern == 1 && directionMove == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

            if (transform.position == target) 
            {
                doorOpen();
                //waiter();
                doorClose();
                directionMove = 2;
            }


        }

        if (bossDebugActive && currentPattern == 1 && directionMove == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, Time.deltaTime * speed);

            if (transform.position == target)
            {
                doorOpen();
                doorClose();
                directionMove = 0;
            }


        }
    }

    void doorOpen() 
    {
        door.transform.eulerAngles = new Vector3(0, -50, 0);
        Debug.Log("Door Opened");
    }

    IEnumerator doorClose() 
    {
        yield return new WaitForSeconds(11);
        door.transform.eulerAngles = new Vector3(0, 0, 0);
        Debug.Log("Door Closed");

        if(directionMove == 2) 
        {
            directionMove = 1;
            //gameObject.transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
            
    }

    
     
}
