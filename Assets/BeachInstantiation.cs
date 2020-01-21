using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachInstantiation : MonoBehaviour
{
    //public GameObject ogre;
    //public float ogreX;
    //public float ogreY;
    //public float ogreZ;
    //public static bool ogredefeated = false;

    //public GameObject crystal;
    //public float crystalY;
    //public float crystalX;
    //public static bool crystalPicked = false;

    public GameObject winSoundTrigger;
    public float soundX;
    public float soundY;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneController.currentScene == "Thebeach")
        {
            if (Portal.hasTalkedWithOldMan == true)
            {
                Instantiate(winSoundTrigger, new Vector3(soundX, soundY), Quaternion.identity);
            }
            //if (ogredefeated == false)
            //{
            //    Instantiate(ogre, new Vector3(ogreX, ogreY, ogreZ), Quaternion.identity);
            //}
            //if (crystal != null && crystalPicked == false)
            //{
            //    Instantiate(crystal, new Vector3(crystalX, crystalY, 758.93f), Quaternion.identity);
            //}
        }
    }

    public void GameOver()
    {
        //ogredefeated = false;
        //crystalPicked = false;
    }
}
