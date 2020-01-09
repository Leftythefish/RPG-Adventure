using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    //whatever objects we need to load to the scene, we are going to add them here
    //public GameObject UIScreen;
    //public GameObject player;
    public GameObject gameManager; //not the same name as the actual script we are talking about
    // Start is called before the first frame update
    void Start()
    {
        //after this, go to unity and instantiate right game objects on UIScreen and player
        //if (UIFade.instance == null)
        //{
        //    UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        //}
        //if (PlayerController.instance == null)
        //{
        //    PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
        //    PlayerController.instance = clone;
        //}
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
