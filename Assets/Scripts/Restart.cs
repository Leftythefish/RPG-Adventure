using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private SceneController sceneController;

    //// Start is called before the first frame update
    //void Start()
    //{
    //}

    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Death();
        }
    }

    public void Win()
    {
        RestartGame();
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        sceneController.LoadScene("Win");
    }

    public void Death()
    {
        RestartGame();
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        sceneController.LoadScene("Death");
    }

    public void RestartGame()
    {
        obj = this.gameObject;

        Inventory.instance.GameOver();
        Player.instance.GameOver();

        Instantiation i = obj.AddComponent<Instantiation>();
        i.GameOver();

        TextBoxManager tbm = FindObjectOfType<TextBoxManager>();
        tbm.openSuccesful = false;
        tbm.ship = false;

        HomeInstantiation hi = obj.AddComponent<HomeInstantiation>();
        hi.GameOver();

        ShedInstantiation si = obj.AddComponent<ShedInstantiation>();
        si.GameOver();

        TownInstantiation ti = obj.AddComponent<TownInstantiation>();
        ti.GameOver();

        //no values to change for now
        //BeachInstantiation bi = obj.AddComponent<BeachInstantiation>();
        //bi.GameOver();

        Forest1Instantiation f1i = obj.AddComponent<Forest1Instantiation>();
        f1i.GameOver();

        Forest2Instantiation f2i = obj.AddComponent<Forest2Instantiation>();
        f2i.GameOver();

        CaveInstantiation ci = obj.AddComponent<CaveInstantiation>();
        ci.GameOver();


        Portal.hasTalkedWithOldMan = false;
        Portal.hasAllCrystals = false;
        RelationShips.homeShroom = 1;

        //AudioManager
    }
}
