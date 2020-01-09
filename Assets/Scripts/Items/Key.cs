
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Key")]
public class Key : Item
{
    public TextAsset lockText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public override void Use()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();

        theTextBox.ReloadScript(lockText);
        theTextBox.currentLine = 2;
        theTextBox.endAtLine = 2;
        theTextBox.openingLock = true;
        theTextBox.item = this;
        theTextBox.EnableTextBox();
    }
}
