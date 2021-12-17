using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void handlePlayButtonClicked()
    {
        SceneManager.LoadScene("OfficeScene");
    }
    public void handleControlsButtonClicked()
    {
        SceneManager.LoadScene("ControlsScene");
    }
}
