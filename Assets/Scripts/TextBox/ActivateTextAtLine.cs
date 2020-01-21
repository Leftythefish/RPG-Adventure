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

    private SceneController sceneController;

    public GameObject houseDoorPortal;
    public float houseDoorPortalX;
    public float houseDoorPortalY;

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

            if (houseDoorPortal != null)
            {
                Instantiate(houseDoorPortal, new Vector3(houseDoorPortalX, houseDoorPortalY), Quaternion.identity);
            }

            //sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
            //sceneController.LoadScene("Home");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<NPC>() != null)
        {
            theTextBox.npc = gameObject.GetComponent<NPC>();

            //does this npc have a friend?
            if (theTextBox.npc.hasFriend == true)
            {
                //answer is different if relationship with friend is good or bad. otherwise default answer.
                int status = RelationShips.GetRelationShip(theTextBox.npc.friendsName);

                if (status < 1)
                {
                    startLine = theTextBox.npc.angryLine;
                    endLine = theTextBox.npc.angryLine;
                }
                else if (status > 1)
                {
                    startLine = theTextBox.npc.happyLine;
                    endLine = theTextBox.npc.happyLine;
                }
            }
        }

        if (collision.CompareTag("Player"))
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);

            if (gameObject.name == "WarningTrigger" && SceneController.currentScene == "Thebeach" && !Portal.hasTalkedWithOldMan)
            {
                startLine = 20;
                endLine = 21;
            }

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

            if (gameObject.name == "WarningTrigger" && SceneController.currentScene == "Thebeach" && Portal.hasTalkedWithOldMan)
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