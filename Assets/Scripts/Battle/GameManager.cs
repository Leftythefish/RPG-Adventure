using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //make this an instance. This script will be running all time during game. this carries player data. lvl and stuff like that
    public static GameManager instance;

    public CharStats[] playerStats;
    public bool battleActive;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
