using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    public TextAsset theText;
    public TextAsset lockText;

    public Item item;

    public bool randomLine;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;


    public bool requireButtonPress;
    private bool waitForPress;
    public bool isLocked;

    public bool destroyWhenActivated;

    private SceneController sceneController;

    public float startTimer;
    public float endTimer;
    private bool startEndTimer = false;

    private bool textShown = false;

    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;

        if (SceneController.currentScene == "Starting_area")
        {
            ShowText();
        }

        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.currentScene == "Prelude")
        {
            if (SceneController.currentScene == "Prelude" && startTimer > 0f)
            {
                startTimer -= Time.deltaTime;
            }
            if (SceneController.currentScene == "Prelude" && startTimer <= 0f && startEndTimer == false && textShown == false)
            {
                ShowText();
            }
            if (theTextBox.currentLine == 14 && startEndTimer == false)
            {
                startEndTimer = true;
            }
            if (startEndTimer)
            {
                endTimer -= Time.deltaTime;
            }
            if (SceneController.currentScene == "Prelude" && endTimer <= 0f)
            {
                Restart r = obj.AddComponent<Restart>();
                r.RestartGame();
                sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
                sceneController.LoadScene("Starting_area");
            }
        }
    }

    void ShowText()
    {

        theTextBox = FindObjectOfType<TextBoxManager>();
        theTextBox.ReloadScript(theText);

        if (randomLine)
        {
            theTextBox.currentLine = Random.Range(startLine, startLine + 2);
            theTextBox.endAtLine = theTextBox.currentLine;
        }
        else
        {
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
        }
        theTextBox.EnableTextBox();

        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }

        textShown = true;
    }

}
