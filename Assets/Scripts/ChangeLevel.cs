using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    //[SerializeField] float LevelLoadDelay = 0.2f;


    [SerializeField] private string toScene;
    private SceneController sceneController;

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//scene loads only if player runs into the portal
        {
            sceneController.LoadScene(toScene);
            //StartCoroutine(LoadNextLevel());
        }
    }

    //IEnumerator LoadNextLevel()
    //{
    //    yield return new WaitForSecondsRealtime(LevelLoadDelay);
    //    var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    sceneController.LoadScene(toScene);
    //}
}
