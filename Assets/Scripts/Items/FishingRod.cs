using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fishing Rod", menuName = "Inventory/FishingRod")]
public class FishingRod : Item
{
    public AudioManager audioManager;
    public int soundToPlay;

    public TextAsset fishingRodText;

    public int noFishingLine;
    public int fishingLine;

    public TextBoxManager theTextBox;

    public static bool canFish = false;

    public bool isFishing;

    public override void Use()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        theTextBox.ReloadScript(fishingRodText);


        if (canFish)
        {
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.PlaySFX(soundToPlay);

            theTextBox.fishing = true;
            theTextBox.fishingTimer = 2f;

            theTextBox.currentLine = fishingLine;
            theTextBox.endAtLine = fishingLine;
            
            theTextBox.EnableTextBox();
        }
        else
        {
            theTextBox.currentLine = noFishingLine;
            theTextBox.endAtLine = noFishingLine;
        }

        theTextBox.EnableTextBox();
    }
}
