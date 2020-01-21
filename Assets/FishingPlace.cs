using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPlace : MonoBehaviour
{
    public TextBoxManager theTextBox;
    public TextAsset fishingAreaText;
    public int noRodLine;
    public int hasRodLine;

    private bool canFish;

    public List<Item> items;

    public int foundSomethingLine;
    public int noCatchLine;

    public int noSpaceLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            theTextBox = FindObjectOfType<TextBoxManager>();
            theTextBox.ReloadScript(fishingAreaText);

            canFish = Inventory.instance.SearchForFishingRod();
            if (canFish)
            {
                theTextBox.currentLine = hasRodLine;
                theTextBox.endAtLine = hasRodLine + 1;
                theTextBox.EnableTextBox();

                FishingRod.canFish = true;
            }
            else
            {
                theTextBox.currentLine = noRodLine;
                theTextBox.endAtLine = noRodLine + 1;
                theTextBox.EnableTextBox();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FishingRod.canFish = false;
        }
    }

    public void Catch()
    {
        int catchIndex = Random.Range(0, 6);

        if (catchIndex < 3)
        {
            bool hasSpace = Inventory.instance.Add(items[catchIndex]);

            if (hasSpace)
            {
                theTextBox.currentLine = foundSomethingLine;
                theTextBox.endAtLine = foundSomethingLine;
            }
            else
            {
                theTextBox.currentLine = noSpaceLine;
                theTextBox.endAtLine = noSpaceLine;
            }
        }

        else
        {
            theTextBox.currentLine = noCatchLine;
            theTextBox.endAtLine = noCatchLine;
        }

        theTextBox.fishing = false;
        theTextBox.EnableTextBox();
    }
}
