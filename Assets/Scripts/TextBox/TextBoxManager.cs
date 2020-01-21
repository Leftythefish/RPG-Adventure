using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;

    public GameObject NameBox;
    public Text nameText;
    public GameObject Options;
    public Text optionsText;

    public TextAsset textFile;
    public string[] textLines;


    public int currentLine;
    public int endAtLine;

    public Player player;
    public NPC npc { get; set; }

    public bool isActive;
    public bool stopPlayerMovement;

    public bool isInteracting;
    //public bool interactDone;
    public int selectedline = 0;
    public bool inventoryFull;

    public bool openingLock;
    public bool openSuccesful;
    public Item item;

    public bool ship = false;

    public bool fishing = false;
    public float fishingTimer;

    public FishingPlace fp;



    // Start is called before the first frame update
    void Start()
    {
        if (InfoToMaintain.startGameText == false)
        {
            isActive = false;
        }

        player = FindObjectOfType<Player>();

        if (textFile != null && InfoToMaintain.startGameText != false)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

        InfoToMaintain.startGameText = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (npc == null || npc.hasInteraction != true) //basic routine if there's no npc or npc is not tagged with interaction
        {
            theText.text = textLines[currentLine];
       
            if (fishing)
            {
                if (fishingTimer > 0f)
                {
                    fishingTimer -= Time.deltaTime;
                    return;
                }
                else
                {
                    fishing = false;
                    fp = FindObjectOfType<FishingPlace>();
                    fp.Catch();
                }
            }

            if (!openingLock && Input.anyKeyDown)
            {
                currentLine += 1;
            }

            if (openingLock && Input.anyKeyDown)
            {
                //currentLine = 4;
                //endAtLine = 4;
                openingLock = false;

                item.RemoveFromInventory();

                openSuccesful = true;
            }



            if (currentLine > endAtLine)
            {
                DisableTextBox();
            }
        }
        else
        {
            if (isInteracting)
            {
                theText.text = textLines[currentLine];
                NPCInteraction();
                return;
            }
            if (!isInteracting && Input.GetKeyDown(KeyCode.Return))
            {
                EndInterAction();
            }
        }
    }

    public void EnableTextBox()
    {
        if (SceneController.currentScene != "Prelude")
        {
            Player.instance.OffRunSpeed();
            Player.instance.MuteWalk();
        }

        if (npc != null && npc.npcName != null)
        {
            NameBox.SetActive(true);
            nameText.text = npc.npcName;
            if (npc.npcName == "Old Man")
            {
                Portal.hasTalkedWithOldMan = true;
            }

            //Player.instance.OffRunSpeed();
        }

        else
        {
            NameBox.SetActive(false);
        }

        if (npc != null && npc.hasInteraction != false)
        {
            isInteracting = true;
            Options.SetActive(true);
        }
        else
        {
            Options.SetActive(false);
        }

        textBox.SetActive(true);
        isActive = true;
        //Player.instance.OffRunSpeed();

        //if (stopPlayerMovement)
        //{
        //    player.canMove = false;
        //}
    }

    public void DisableTextBox()
    {
        theText.text = " ";

        textBox.SetActive(false);
        isActive = false;
        npc = null;

        if (Portal.hasAllCrystals == true)
        {
            Restart r = FindObjectOfType<Restart>();
            r.Win();
            Player.instance.OnRunSpeed();
            Player.instance.UnMuteWalk();
            return;
        }
        else if (ship)
        {
            Restart r = FindObjectOfType<Restart>();
            r.Win();
            Player.instance.OnRunSpeed();
            Player.instance.UnMuteWalk();
            return;
        }

        Player.instance.OnRunSpeed();
        Player.instance.UnMuteWalk();

        player.canMove = true;

    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }

    public void NPCInteraction()
    {
        //player.canMove = false;

        optionsText.text = npc.playerDialogueLines[selectedline];

        if (Input.GetKeyDown(KeyCode.DownArrow))//down
        {

            if (selectedline != npc.playerDialogueLines.Length - 1)
            {
                selectedline += 1;
                optionsText.text = npc.playerDialogueLines[selectedline];
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))//up
        {
            if (selectedline != 0)
            {
                selectedline -= 1;
                optionsText.text = npc.playerDialogueLines[selectedline];
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))//enter
        {
            if (npc.item != null)
            {
                if (selectedline == npc.itemAnswer)
                {
                    bool hadspace = Inventory.instance.Add(npc.item);
                    if (hadspace)
                    {
                        theText.text = npc.npcDialogueLines[npc.itemGiven];
                        npc.item = null;
                        HomeInstantiation.potionGiven = true;
                    }
                    else
                    {
                        theText.text = npc.npcDialogueLines[npc.npcDialogueLines.Length - 1];
                    }
                }
                else
                {
                    theText.text = npc.npcDialogueLines[selectedline];
                }
            }
            else
            {
                theText.text = npc.npcDialogueLines[selectedline];
            }

            if (npc.hasRelationship)
            {
                if (selectedline == npc.badAnswer)
                {
                    RelationShips.UpdateRelationShip(-1);
                }
                else if (selectedline == npc.goodAnswer)
                {
                    RelationShips.UpdateRelationShip(1);
                }
            }

            selectedline = 0;
            isInteracting = false;
        }
    }

    public void EndInterAction()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isInteracting = false;
            DisableTextBox();
            npc = null;
        }
    }
}
