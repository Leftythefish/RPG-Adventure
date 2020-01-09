using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public TextAsset chestText;
    public int itemFoundStartLine;
    public int itemFoundEndLine;
    public int emptyStartLine;
    public int emptyEndLine;
    public int chestNumber;
    public TextBoxManager theTextBox;

    public List<Item> items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//scene loads only if player runs into the portal
        {
            theTextBox = FindObjectOfType<TextBoxManager>();

            if (items == null || items.Count == 0)
            {
                theTextBox.ReloadScript(chestText);
                theTextBox.currentLine = emptyStartLine;
                theTextBox.endAtLine = emptyEndLine;
                theTextBox.EnableTextBox();
            }
            else
            {
                foreach (var item in items)
                {
                    Inventory.instance.Add(item);
                }

                theTextBox.ReloadScript(chestText);
                theTextBox.currentLine = itemFoundStartLine;
                theTextBox.endAtLine = itemFoundEndLine;
                theTextBox.EnableTextBox();

                items = null;

                DisableChest();
            }

        }
    }

    private void DisableChest()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Home":
                switch (chestNumber)
                {
                    case 1:
                        HomeInstantiation.chestOpened = true;
                        break;
                    default:
                        break;
                }
                break;
            case "Shed":
                switch (chestNumber)
                {
                    case 1:
                        ShedInstantiation.chest1Opened = true;
                        break;
                    case 2:
                        ShedInstantiation.chest2Opened = true;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
