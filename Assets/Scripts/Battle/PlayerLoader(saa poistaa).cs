using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    //we want to spawn new player if none exists in a scene
    public GameObject Player; //want to load a object to a world (Player)
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        {
            Instantiate(Player);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
