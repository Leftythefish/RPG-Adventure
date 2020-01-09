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
        Inventory.instance.GameOver();
        Player.instance.GameOver();

        Instantiation i = new Instantiation();
        i.GameOver();

        TextBoxManager tbm = FindObjectOfType<TextBoxManager>();
        tbm.openSuccesful = false;
        tbm.ship = false;

        HomeInstantiation hi = new HomeInstantiation();
        hi.GameOver();

        ShedInstantiation si = new ShedInstantiation();
        si.GameOver();

        TownInstantiation ti = new TownInstantiation();
        ti.GameOver();

        BeachInstantiation bi = new BeachInstantiation();
        bi.GameOver();

        Forest1Instantiation f1i = new Forest1Instantiation();
        f1i.GameOver();

        Forest2Instantiation f2i = new Forest2Instantiation();
        f2i.GameOver();

        CaveInstantiation ci = new CaveInstantiation();
        ci.GameOver();

        Portal.hasTalkedWithOldMan = false;
        Portal.hasAllCrystals = false;

        //AudioManager
    }
}
