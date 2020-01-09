using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    public string npcName;
    public bool hasInteraction;
    public string[] playerDialogueLines;
    public string[] npcDialogueLines;
    public Item item;
    public int itemAnswer;
    public int itemGiven;

}
