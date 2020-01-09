using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaster : MonoBehaviour
{
    public static UIMaster instance;

    public GameObject essentialsLoader;
    public GameObject textBoxManager;
    public GameObject GameManager;
    public GameObject floatingUI;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of UIMaster found!");
            Destroy(this);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
