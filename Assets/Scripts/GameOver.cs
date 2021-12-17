using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject redWall;
    // Start is called before the first frame update
    void Start()
    {
        redWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRed() 
    {
        redWall.SetActive(true);
    }
}
