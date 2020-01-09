using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{
    public TextAsset theText;
    public TextAsset lockText;

    public Item item;

    public bool randomLine;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;


    public bool requireButtonPress;
    private bool waitForPress = false;
    public bool isLocked;

    public bool destroyWhenActivated;

    // Start is called before the first frame update
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Space) && !isLocked)
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }

        if (waitForPress && isLocked && Input.GetKeyDown(KeyCode.Space))
        {
            item = (from i in Inventory.items
                    where i.name == "Key"
                    select i).FirstOrDefault();

            if (item != null)
            {
                item.Use();
            }

            else
            {
                if (!theTextBox.isActive)
                {
                    theTextBox.ReloadScript(theText);
                    theTextBox.currentLine = startLine;
                    theTextBox.endAtLine = endLine;
                    theTextBox.EnableTextBox();
                    return;
                }
            }
        }

        if (theTextBox.openSuccesful == true)
        {
            isLocked = false;
            Instantiation.houseDoorOpened = true;
            //ChangeLevel c = GetComponent<ChangeLevel>();
            //if (c != null)
            //{
            //    c.enabled = true;
            //    Instantiation.houseDoorOpened = true;
            //}

            //Collider2D k = GetComponent<Collider2D>();

            //OnTriggerExit2D(k);
            //OnTriggerEnter2D(k);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<NPC>() != null)
        {
            theTextBox.npc = gameObject.GetComponent<NPC>();
        }

        if (collision.CompareTag("Player"))
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

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
            if (gameObject.name == "townenter-warning(Clone)")
            {
                TownInstantiation.warningShown = true;
            }
            if (gameObject.name == "cavehint-warning")
            {
                Forest1Instantiation.warningShownCave = true;
            }
            if (gameObject.name == "WarningTrigger" && SceneController.currentScene == "Thebeach")
            {
                theTextBox.ship = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            waitForPress = false;
            theTextBox.openSuccesful = false;
        }
    }
}