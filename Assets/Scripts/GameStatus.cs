using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //protected int lives = 3;

    public GameObject inventory;

    //protected List<Item>;

    static GameStatus instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameStatus found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

        //protected List<Item>;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
