using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeInstantiation : MonoBehaviour
{

    public GameObject angryShroom;
    public float shroomX;
    public float shroomY;
    public float shroomZ;
    public static bool potionGiven = false;

    public GameObject healthPotion;
    public float healthX;
    public float healthY;
    public static bool healthPicked = false;

    public GameObject poisonPotion;
    public float poisonX;
    public float poisonY;
    public static bool poisonPicked = false;

    public GameObject chest;
    public float chestX;
    public float chestY;
    public static bool chestOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (healthPotion != null && healthPicked == false)
        //{
        //    Instantiate(healthPotion, new Vector3(healthX, healthY), Quaternion.identity);
        //}
        //if (poisonPotion != null && poisonPicked == false)
        //{
        //    Instantiate(poisonPotion, new Vector3(poisonX, poisonY), Quaternion.identity);
        //}
        if (chest != null)
        {
            if (chestOpened)
            {
                Chest c = chest.gameObject.GetComponent<Chest>();
                c.items = null;
            }
            Instantiate(chest, new Vector3(chestX, chestY), Quaternion.identity);
        }

        if (potionGiven)
        {
            NPC npc = angryShroom.GetComponent<NPC>();
            npc.item = null;
        }
        Instantiate(angryShroom, new Vector3(shroomX, shroomY, shroomZ), Quaternion.identity);
    }

    public void GameOver()
    {
        healthPicked = false;
        poisonPicked = false;
        chestOpened = false;
        potionGiven = false;
    }
}
