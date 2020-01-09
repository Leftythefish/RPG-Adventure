using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    private SceneController sceneController;
    public void LoadNextScene()
    {
        //sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        sceneController.LoadScene("Starting_area");
        //sceneController.LoadScene("Prelude");

    }
    public void LoadStartScene()
    {
        //SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
