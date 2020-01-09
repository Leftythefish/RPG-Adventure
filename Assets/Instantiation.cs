using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiation : MonoBehaviour
{
    public GameObject key;
    public float keyX;
    public float keyY;
    public static bool keyPicked = false;
    public GameObject healthPotion;
    public float healthX;
    public float healthY;
    public static bool healthPicked = false;
    public GameObject speedPotion;
    public float speedX;
    public float speedY;
    public static bool speedPicked = false;
    public GameObject poisonPotion;
    public float poisonX;
    public float poisonY;
    public static bool poisonPicked = false;

    public GameObject houseDoorCollider;
    public float houseDoorCollX;
    public float houseDoorCollY;
    public GameObject houseDoorPortal;
    public float houseDoorPortalX;
    public float houseDoorPortalY;
    public static bool houseDoorOpened = false;
    private static bool houseDoorIsOpen = false;
    public GameObject shedDoorCollider;
    public float shedDoorX;
    public float shedDoorY;

    public GameObject ogre;
    public float ogreX;
    public float ogreY;
    public float ogreZ;
    public static bool ogredefeated = false;

    public GameObject gameStartInfo;
    public float startX;
    public float startY;
    public static bool warningShown = false;

    // Start is called before the first frame update
    void Start()
    {
        if (warningShown == false)
        {
            Instantiate(gameStartInfo, new Vector3(startX, startY), Quaternion.identity);
            warningShown = true;
        }
        if (key != null && keyPicked == false)
        {
            Instantiate(key, new Vector3(keyX, keyY), Quaternion.identity);
        }
        if (healthPotion != null && healthPicked == false)
        {
            Instantiate(healthPotion, new Vector3(healthX, healthY), Quaternion.identity);
        }
        if (speedPotion != null && speedPicked == false)
        {
            Instantiate(speedPotion, new Vector3(speedX, speedY), Quaternion.identity);
        }
        if (poisonPotion != null && poisonPicked == false)
        {
            Instantiate(poisonPotion, new Vector3(poisonX, poisonY), Quaternion.identity);
        }
        if (houseDoorOpened == false)
        {
            Instantiate(houseDoorCollider, new Vector3(houseDoorCollX, houseDoorCollY), Quaternion.identity);
        }
        if (houseDoorOpened == true)
        {
            Instantiate(houseDoorPortal, new Vector3(houseDoorPortalX, houseDoorPortalY), Quaternion.identity);
        }

        Instantiate(shedDoorCollider, new Vector3(shedDoorX, shedDoorY), Quaternion.identity);

        if (ogredefeated == false)
        {
            Instantiate(ogre, new Vector3(ogreX, ogreY, ogreZ), Quaternion.identity);
        }
    }

    private void Update()
    {
        if (houseDoorOpened == true && !houseDoorIsOpen && Input.GetKeyDown(KeyCode.Return))
        {
            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            Instantiate(houseDoorPortal, new Vector3(houseDoorPortalX, houseDoorPortalY), Quaternion.identity);
            Destroy(houseDoorCollider);
            //}
            houseDoorIsOpen = true;
        }

        //if (ogredefeated == true)
        //{
        //    Destroy(ogre);
        //}
    }

    public void GameOver()
    {
        keyPicked = false;
        healthPicked = false;
        speedPicked = false;
        poisonPicked = false;
        houseDoorOpened = false;
        houseDoorIsOpen = false;
        ogredefeated = false;
        warningShown = false;
    }

}
