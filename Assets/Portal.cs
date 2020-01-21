using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public TextAsset portalText;
    public TextBoxManager theTextBox;
    public int winStartLine;
    public int winEndLine;
    public int noKeysStartLine;
    public int noKeysEndLine;
    public int whatIsThisStartLine;
    public int whatIsThisEndLine;

    public static bool hasAllCrystals = false;

    public static bool hasTalkedWithOldMan = false;

    public AudioManager audioManager;
    public int defaultSound;
    public int noCrystalsSound;
    public int hasCrystalsSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theTextBox = FindObjectOfType<TextBoxManager>();

        if (collision.CompareTag("Player"))//scene loads only if player runs into the portal
        {
            audioManager = FindObjectOfType<AudioManager>();

            if (hasTalkedWithOldMan)
            {
                hasAllCrystals = Inventory.instance.SearchForCrystals();

                if (hasAllCrystals)
                {
                    audioManager.PlaySFX(hasCrystalsSound);

                    theTextBox.ReloadScript(portalText);
                    theTextBox.currentLine = winStartLine;
                    theTextBox.endAtLine = winEndLine;
                    theTextBox.EnableTextBox();
                }
                else
                {
                    audioManager.PlaySFX(noCrystalsSound);

                    theTextBox.ReloadScript(portalText);
                    theTextBox.currentLine = noKeysStartLine;
                    theTextBox.endAtLine = noKeysEndLine;
                    theTextBox.EnableTextBox();
                }
            }

            else
            {
                audioManager.PlaySFX(defaultSound);

                theTextBox.ReloadScript(portalText);
                theTextBox.currentLine = whatIsThisStartLine;
                theTextBox.endAtLine = whatIsThisEndLine;
                theTextBox.EnableTextBox();
            }
        }
    }
}
