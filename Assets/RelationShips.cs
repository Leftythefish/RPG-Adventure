using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RelationShips : MonoBehaviour
{

    public static int homeShroom = 1;

    //// Start is called before the first frame update
    
    //void Start()
    //{
    //    //GameObject.DontDestroyOnLoad(this.gameObject);
    //}
    
    public static void UpdateRelationShip(int effect)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Home":
                homeShroom += effect;
                break;
            default:
                break;
        }
    }

    public static int GetRelationShip(string friendsName)
    {
        int status = 1;

        //name of the npc:s friend
        switch (friendsName)
        {
            case "ShroomAngry":
                status = homeShroom;
                break;
            default:
                break;
        }
        return status;
    }

    //public void GameOver()
    //{
    //    homeShroom = 1;
    //}
}
