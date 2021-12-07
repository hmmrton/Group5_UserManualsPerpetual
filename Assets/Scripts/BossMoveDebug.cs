using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveDebug : MonoBehaviour
{
    public bool bossDebugActive;

    private Vector3 target = new Vector3(10.79f, 2.79f, 57.15f);
    private Vector3 target1 = new Vector3(-7.79f, 2.79f, 57.15f);
    private Vector3 target2 = new Vector3(-1.489339f, 2.79f, 57.15f);
    public float speed;
    private int currentPattern;
    public GameObject door;
    private int directionMove;
    public GameObject bossLook;

    //Random rand = new Random();
    private int bossAIValue;

    public AudioClip clip;
    AudioSource audioSource;
    


    void Start() 
    {
        bossLook.transform.localScale = new Vector3(0, 0, 0);
        
        door.transform.eulerAngles = new Vector3(0, 0, 0);
        directionMove = 0;
        //rand = new Random();
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
        
        /*if (currentPattern == 3)
        {
            if (transform.position != target1 && transform.position != target) 
            {
                StartCoroutine(waitBoss());
                //waitBoss();
                Debug.Log("Stalling...");
            }


            
        }*/
        else 
        {
            DebugCommand();
        }

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
                StartCoroutine(lookForward());
                currentPattern = 1;
                directionMove = 1;
            }
        }

        if (transform.position == target1)
        {
            directionMove = 0;
            currentPattern = 0;
        }
    }


    IEnumerator lookForward() 
    {
        //yield return new WaitForSeconds(3);
        transform.localScale = new Vector3(0, 0, 0);
        bossLook.transform.localScale = new Vector3(3.58271f, 5.58494f, 4.4428f);

        yield return new WaitForSecondsRealtime(2);
        transform.localScale = new Vector3(3.58271f, 5.58494f, 4.4428f);
        bossLook.transform.localScale = new Vector3(0, 0, 0);
    }

    void doorOpen() 
    {
        door.transform.eulerAngles = new Vector3(0, -50, 0);
        Debug.Log("Door Opened");
        audioSource.Play();
    }

    IEnumerator doorClose() 
    {
        yield return new WaitForSecondsRealtime(9);
        doorOpen();
        yield return new WaitForSecondsRealtime(2);
        door.transform.eulerAngles = new Vector3(0, 0, 0);
        Debug.Log("Door Closed");
        
    }

    /*IEnumerator waitBoss() 
    {
        int timeWait = Random.Range(3, 4);
        yield return new WaitForSecondsRealtime(timeWait);

        //if(timeWait < 5)
            currentPattern = 0;
    }*/
    
     
}
