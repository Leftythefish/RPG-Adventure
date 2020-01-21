using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest2Instantiation : MonoBehaviour
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


    public GameObject crystal;
    public float crystalY;
    public float crystalX;
    public static bool crystalPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneController.currentScene == "Theforest_02")
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
            //if (ogredefeated == false)
            //{
            //    Instantiate(ogre, new Vector3(ogreX, ogreY, ogreZ), Quaternion.identity);
            //}
            if (crystal != null && crystalPicked == false)
            {
                Instantiate(crystal, new Vector3(crystalX, crystalY, 758.93f), Quaternion.identity);
            }
        }
    }

    public void GameOver()
    {
        ogredefeated = false;
        crystalPicked = false;
    }
}
