using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownInstantiation : MonoBehaviour
{

    public GameObject enterWarning;
    public float warningX;
    public float warningY;
    public static bool warningShown = false;

    public GameObject crystal;
    public float crystalY;
    public float crystalX;
    public static bool crystalPicked = false;

    //public GameObject poisonPotion;
    //public float poisonX;
    //public float poisonY;
    //public static bool poisonPicked = false;

    public GameObject ogre1;
    public float ogre1X;
    public float ogre1Y;
    public float ogre1Z;
    public static bool ogre1defeated = false;

    public GameObject ogre2;
    public float ogre2X;
    public float ogre2Y;
    public float ogre2Z;
    public static bool ogre2defeated = false;

    public GameObject ogre3;
    public float ogre3X;
    public float ogre3Y;
    public float ogre3Z;
    public static bool ogre3defeated = false;

    public GameObject ogre4;
    public float ogre4X;
    public float ogre4Y;
    public float ogre4Z;
    public static bool ogre4defeated = false;

    public GameObject ogre5;
    public float ogre5X;
    public float ogre5Y;
    public float ogre5Z;
    public static bool ogre5defeated = false;

    public GameObject ogre6;
    public float ogre6X;
    public float ogre6Y;
    public float ogre6Z;
    public static bool ogre6defeated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (warningShown == false)
        {
            Instantiate(enterWarning, new Vector3(warningX, warningY), Quaternion.identity);
            //warningShown = true;
        }
        if (crystal != null && crystalPicked == false)
        {
            Instantiate(crystal, new Vector3(crystalX, crystalY, 758.93f), Quaternion.identity);
        }
        //if (poisonPotion != null && poisonPicked == false)
        //{
        //    Instantiate(poisonPotion, new Vector3(poisonX, poisonY), Quaternion.identity);
        //}
        if (ogre1defeated == false)
        {
            Instantiate(ogre1, new Vector3(ogre1X, ogre1Y, ogre1Z), Quaternion.identity);
        }
        if (ogre2defeated == false)
        {
            Instantiate(ogre2, new Vector3(ogre2X, ogre2Y, ogre2Z), Quaternion.identity);
        }
        if (ogre3defeated == false)
        {
            Instantiate(ogre3, new Vector3(ogre3X, ogre3Y, ogre3Z), Quaternion.identity);
        }
        if (ogre4defeated == false)
        {
            Instantiate(ogre4, new Vector3(ogre4X, ogre4Y, ogre4Z), Quaternion.identity);
        }
        if (ogre5defeated == false)
        {
            Instantiate(ogre5, new Vector3(ogre5X, ogre5Y, ogre5Z), Quaternion.identity);
        }
        if (ogre6defeated == false)
        {
            Instantiate(ogre6, new Vector3(ogre6X, ogre6Y, ogre6Z), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        warningShown = false;
        crystalPicked = false;
        ogre1defeated = false;
        ogre2defeated = false;
        ogre3defeated = false;
        ogre4defeated = false;
        ogre5defeated = false;
        ogre6defeated = false;
    }
}
