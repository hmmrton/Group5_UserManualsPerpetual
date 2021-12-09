using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveDebug : MonoBehaviour
{
    public bool bossDebugActive;

    private Vector3 target = new Vector3(10.8f, 2.79f, 57.15f);
    private Vector3 targetGameOverTrigger = new Vector3(10.79f, 2.79f, 57.15f);
    private Vector3 target1 = new Vector3(-7.79f, 2.79f, 57.15f);
    private Vector3 target2 = new Vector3(-1.489339f, 2.79f, 57.15f);
    private Vector3 target3 = new Vector3(-22.489339f, 3.79f, 57.15f);
    public float speed;
    private int currentPattern;
    public GameObject door;
    Door doorScript;
    private int directionMove;
    public GameObject bossLookWindow;
    public GameObject bossLookDoor;
    public static bool doorCheck;

    //Random rand = new Random();
    private int bossAIValue;

    public AudioClip clip;
    AudioSource audioSource;
    
    void Start() 
    {
        doorCheck = false;
        bossLookDoor.transform.localScale = Vector3.zero;
        bossLookWindow.transform.localScale = Vector3.zero;
        doorScript = door.GetComponent<Door>();
        doorScript.closeDoor();
        directionMove = 0;
        bossAIValue = 0;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bossDebugActive)
            DebugCommand();
        else
            autoAction();
    }

    void autoAction() 
    {
        if (currentPattern == 0) 
        {
            bossAIValue = Random.Range(1, 3);
            currentPattern = bossAIValue;
        }
        if (currentPattern == 1 && transform.position == target1) 
        {
            StartCoroutine(doorClose());
        }
        if (currentPattern >= 3)
        {
            if (transform.position != target3)
            {
                transform.position = Vector3.MoveTowards(transform.position, target3, Time.deltaTime * speed);

            }
            else
            {
                StartCoroutine(waitBoss());
                //waitBoss();
                Debug.Log("Stalling...");
                currentPattern = 0;
            }
        }
        DebugCommand();
        if (transform.position == target1 && currentPattern < 3 || transform.position == target && currentPattern < 3)
            currentPattern = 0;
    }

    void DebugCommand() 
    {
        if (Input.GetKeyDown("1") && bossDebugActive)
        {
            currentPattern = 1;
            Debug.Log("Inititating Pattern One");
            StartCoroutine(doorClose());
        }
        if (currentPattern == 1 && directionMove == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            if (transform.position == target)
            {
                //doorOpen();
                //waiter();
                //doorClose();
                directionMove = 2;
            }
        }
        if (currentPattern == 1 && directionMove == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, Time.deltaTime * speed);
            if (transform.position == target)
            {
                doorOpen();
                //doorClose();
                directionMove = 0;
                //gameObject.transform.eulerAngles = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKeyDown("2") && bossDebugActive)
        {
            currentPattern = 2;
            Debug.Log("Inititating Pattern Two");
        }

        if (currentPattern == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2, Time.deltaTime * speed);
            if (transform.position == target2)
            {
                Debug.Log("Shrinking");
                StartCoroutine(lookForward(bossLookWindow));
                currentPattern = 1;
                directionMove = 1;
            }
        }

        if (Input.GetKeyDown("3") && bossDebugActive)
        {
            currentPattern = 3;
            Debug.Log("Inititating Pattern Three");
        }

        if (currentPattern >= 3 && bossDebugActive)
        {
            if (transform.position != target3)
            {
                transform.position = Vector3.MoveTowards(transform.position, target3, Time.deltaTime * speed);
            }
            else
            {
                StartCoroutine(waitBoss());
                //waitBoss();
                Debug.Log("Stalling...");
                currentPattern = 0;
            }
        }

        if (transform.position == target1)
        {
            directionMove = 0;
            currentPattern = 0;
        }
    }


    IEnumerator lookForward(GameObject bossLook, bool doorLook = false)
    {
        //yield return new WaitForSecondsRealtime(3);
        transform.localScale = Vector3.zero;
        bossLook.transform.localScale = new Vector3(3.58271f, 5.58494f, 4.4428f);

        yield return new WaitForSecondsRealtime(2);
        if (doorLook)
        {
            doorCheck = true;
            yield return new WaitForSecondsRealtime(1);
            doorCheck = false;
        }
        transform.localScale = new Vector3(3.58271f, 5.58494f, 4.4428f);
        bossLook.transform.localScale = Vector3.zero;
    }

    void doorOpen() 
    {
        doorScript.openDoor();
        Debug.Log("Door Opened");
        audioSource.Play();
    }

    IEnumerator doorClose() 
    {
        yield return new WaitForSecondsRealtime(9);
        doorOpen();
        yield return lookForward(bossLookDoor, true);
        doorScript.closeDoor();
        Debug.Log("Door Closed");
    }
    IEnumerator waitBoss()
    {
        int timeWait = Random.Range(3, 4);
        yield return new WaitForSecondsRealtime(timeWait);
        //if(timeWait < 5)
        currentPattern = 0;
    }
}
