using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShedInstantiation : MonoBehaviour
{
    //public GameObject key;
    //public float keyX;
    //public float keyY;
    //public static bool keyPicked = false;
    //public GameObject healthPotion;
    //public float healthX;
    //public float healthY;
    //public static bool healthPicked = false;
    //public GameObject speedPotion;
    //public float speedX;
    //public float speedY;
    //public static bool speedPicked = false;
    //public GameObject poisonPotion;
    //public float poisonX;
    //public float poisonY;
    //public static bool poisonPicked = false;

    public GameObject ogre;
    public float ogreX;
    public float ogreY;
    public float ogreZ;
    public static bool ogredefeated = false;

    public GameObject chest1;
    public float chest1X;
    public float chest1Y;
    public static bool chest1Opened = false;

    public GameObject chest2;
    public float chest2X;
    public float chest2Y;
    public static bool chest2Opened = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneController.currentScene == "Shed")
        {
            //if (key != null && keyPicked == false)
            //{
            //    Instantiate(key, new Vector3(keyX, keyY), Quaternion.identity);
            //}
            //if (healthPotion != null && healthPicked == false)
            //{
            //    Instantiate(healthPotion, new Vector3(healthX, healthY), Quaternion.identity);
            //}
            //if (speedPotion != null && speedPicked == false)
            //{
            //    Instantiate(speedPotion, new Vector3(speedX, speedY), Quaternion.identity);
            //}
            //if (poisonPotion != null && poisonPicked == false)
            //{
            //    Instantiate(poisonPotion, new Vector3(poisonX, poisonY), Quaternion.identity);
            //}
            if (ogre != null && ogredefeated == false)
            {
                Instantiate(ogre, new Vector3(ogreX, ogreY, ogreZ), Quaternion.identity);
            }

            if (chest1 != null)
            {
                if (chest1Opened)
                {
                    Chest c = chest1.gameObject.GetComponent<Chest>();
                    c.items = null;
                }
                Instantiate(chest1, new Vector3(chest1X, chest1Y), Quaternion.identity);
            }
            if (chest2 != null)
            {
                if (chest2Opened)
                {
                    Chest c = chest2.gameObject.GetComponent<Chest>();
                    c.items = null;
                }
                Instantiate(chest2, new Vector3(chest2X, chest2Y), Quaternion.identity);
            }
        }
    }

    public void GameOver()
    {
        ogredefeated = false;
        chest1Opened = false;
        chest2Opened = false;
    }
}
