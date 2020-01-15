using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fishing Rod", menuName = "Inventory/FishingRod")]
public class FishingRod : Item
{
    public TextAsset fishingRodText;

    public int noFishingLine;
    public int fishingLine;

    public int foundSomethingLine;
    public int noCatchLine;

    public TextBoxManager theTextBox;

    public List<Item> items;

    public static bool canFish = false;

    public override void Use()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        theTextBox.ReloadScript(fishingRodText);

        if (canFish)
        {
            Debug.Log("Fishing");

            theTextBox.currentLine = fishingLine;
            theTextBox.endAtLine = fishingLine;

            theTextBox.EnableTextBox();

            int catchIndex = Random.Range(0, 7);

            if (catchIndex < 3)
            {
                Inventory.instance.Add(items[catchIndex]);

                theTextBox.currentLine = foundSomethingLine;
                theTextBox.endAtLine = foundSomethingLine;
            }

            else
            {
                theTextBox.currentLine = noCatchLine;
                theTextBox.endAtLine = noCatchLine;
            }
        }
        else
        {
            Debug.Log("Can't fish here");
            theTextBox.currentLine = noFishingLine;
            theTextBox.endAtLine = noFishingLine;
        }

        theTextBox.EnableTextBox();
    }
}
