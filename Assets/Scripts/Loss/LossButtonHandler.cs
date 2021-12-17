using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossButtonHandler : MonoBehaviour
{
    public void handleBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
