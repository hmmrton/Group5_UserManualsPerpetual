using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject brickBreakerPlayMenu;
    public GameObject brickBreakerLossMenu;
    public GameObject brickBreakerWinMenu;
    bool bbPlayMenuZoomedState;
    bool bbLossMenuZoomedState;
    bool bbWinMenuZoomedState;
    //Stack<HashSet<bool>> states; // only need 1 place in stack so not really worth
    bool zoomed;
    // Start is called before the first frame update
    void Start()
    {
        bbPlayMenuZoomedState = bbLossMenuZoomedState = bbWinMenuZoomedState = false;
        zoomed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomed && !ComputerFocusCamera.zoomed)
        {
            Debug.Log("no longer zoomed "
                + brickBreakerPlayMenu.activeInHierarchy + " "
                + brickBreakerLossMenu.activeInHierarchy + " "
                + brickBreakerWinMenu.activeInHierarchy
            );
            // no longer zoomed
            bbPlayMenuZoomedState = brickBreakerPlayMenu.activeInHierarchy;
            bbLossMenuZoomedState = brickBreakerLossMenu.activeInHierarchy;
            bbWinMenuZoomedState = brickBreakerWinMenu.activeInHierarchy;
            // remove overlays but store ui state
            brickBreakerPlayMenu.SetActive(false);
            brickBreakerLossMenu.SetActive(false);
            brickBreakerWinMenu.SetActive(false);
        }
        else if (!zoomed && ComputerFocusCamera.zoomed)
        {
            Debug.Log("no longer zoomed "
                + bbPlayMenuZoomedState + " "
                + bbLossMenuZoomedState + " "
                + bbWinMenuZoomedState
            );
            // just zoomed
            brickBreakerPlayMenu.SetActive(bbPlayMenuZoomedState);
            brickBreakerLossMenu.SetActive(bbLossMenuZoomedState);
            brickBreakerWinMenu.SetActive(bbWinMenuZoomedState);
        }
        zoomed = ComputerFocusCamera.zoomed;
    }
}
