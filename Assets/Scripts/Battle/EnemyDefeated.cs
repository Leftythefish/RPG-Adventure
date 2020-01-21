using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyDefeated : MonoBehaviour
{
    //public static EnemyDefeated instance;
    // Start is called before the first frame update
    //void Start()
    ////{
    ////    if (instance!=null)
    ////    {
    ////        Destroy(this);
    ////        return;
    ////    }
    ////    instance = this;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void DetermineDefeated(string enemyname)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Starting_area":
                switch (enemyname)
                {
                    case "Ogre1":
                        Instantiation.ogredefeated = true;
                        break;
                    default:
                        break;
                }
                break;
            case "TheTown_01":
                switch (enemyname)
                {
                    case "Ogre1":
                        TownInstantiation.ogre1defeated = true;
                        break;
                    case "Ogre2":
                        TownInstantiation.ogre2defeated = true;
                        break;
                    case "Ogre3":
                        TownInstantiation.ogre3defeated = true;
                        break;
                    //case "Ogre4":
                    //    TownInstantiation.ogre4defeated = true;
                    //    break;
                    case "Ogre5":
                        TownInstantiation.ogre5defeated = true;
                        break;
                    case "Ogre6":
                        TownInstantiation.ogre6defeated = true;
                        break;
                }
                break;
        }

        return;
    }
}
