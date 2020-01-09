using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndText : MonoBehaviour
{
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;

    public int soundToPlay;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<NPC>() != null)
        {
            theTextBox.npc = gameObject.GetComponent<NPC>();
        }

        if (collision.CompareTag("Player"))
        {
            theTextBox.ReloadScript(theText);

            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            audioManager.PlaySFX(soundToPlay);

            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
                Forest1Instantiation.warningShownCave = true;
            }
        }
    }

}

