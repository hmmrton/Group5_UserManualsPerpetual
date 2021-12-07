using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DesktopIcon : MonoBehaviour
{
    Button button;
    public GameObject BrickBreakerScenePrefab;

    // Start is called before the first frame update
    /*void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(handleOnClick);
        Debug.Log("init buttonm");
    }

    void handleOnClick()
    {
        Debug.Log("loading " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }*/

    public void handleBrickBreakerButtonClicked()
    {
        if (!GameManagerBrickBreaker.gameComplete) // once game complete, disable game
            Instantiate(BrickBreakerScenePrefab);
    }
}
