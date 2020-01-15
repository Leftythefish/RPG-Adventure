using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPlace : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //}
    public TextBoxManager theTextBox;
    public TextAsset fishingAreaText;
    public int noRodLine;
    public int hasRodLine;

    private bool canFish;

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
                theTextBox.endAtLine = noRodLine+1;
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

    //    // Update is called once per frame
    //    void Update()
    //{

    //}
}
