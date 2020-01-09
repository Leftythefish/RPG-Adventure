using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public float timer;

    private SceneController sceneController;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f || Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.instance.Destroy();
            sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
            sceneController.LoadScene("MainMenu");
        }
    }
}
