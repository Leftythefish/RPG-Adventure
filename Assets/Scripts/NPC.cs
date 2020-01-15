using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    public string npcName;
    public string[] npcDialogueLines;

    public bool hasInteraction;
    public string[] playerDialogueLines;

    public Item item;
    //index for correct player answer to get item
    public int itemAnswer;
    //index for npc:s answer if item is given
    public int itemGiven;

    //can your answers affect relationship with this npc?
    public bool hasRelationship;
    //index for an answer that makes relationship worse
    public int badAnswer;
    //index for an answer that makes relationship better
    public int goodAnswer;

    //is this npc:s answer dependent on a relationship to other npc
    public bool hasFriend;
    //friends name
    public string friendsName;
    //if relationship with friend is good
    public int happyLine;
    //if relationship with friend is bad
    public int angryLine;
}
