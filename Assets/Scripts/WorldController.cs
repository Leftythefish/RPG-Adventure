using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : SceneController
{

    public Transform player;
    public int musicToPlay;
    private bool musicStarted;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //string positionSelector = (prevScene + currentScene);
        switch (prevScene)
        {
            case "Starting_area":
                switch (currentScene)
                {
                    case "Theforest_01":
                        player.position = new Vector2(3f, 21f);
                        break;
                    case "Home":
                        player.position = new Vector2(5.79f, 3.19f);
                        break;
                    case "Shed":
                        player.position = new Vector2(11.3f, 0.17f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;
            case "Home":
                switch (currentScene)
                {
                    case "Starting_area":
                        player.position = new Vector2(6.7f, 5.3f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;
            case "Cave":
                switch (currentScene)
                {
                    case "Theforest_01":
                        player.position = new Vector2(42.36f, -1.12f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;
            case "Thebeach":
                switch (currentScene)
                {
                    case "Theforest_02":
                        player.position = new Vector2(10f, -9f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;
            case "Theforest_01":
                switch (currentScene)
                {
                    case "Starting_area":
                        player.position = new Vector2(3f, -8f);
                        break;
                    case "TheTown_01":
                        player.position = new Vector2(-14f, 21f);
                        break;
                    case "Theforest_02":
                        player.position = new Vector2(2.5f, 20.5f);
                        break;
                    case "Cave":
                        player.position = new Vector2(12.9f, 6.65f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;

            case "TheTown_01":
                if (currentScene == "Theforest_01")
                {
                    player.position = new Vector2(42.2f, -9.6f);

                }
                else if (currentScene == "Theforest_02")
                {
                    player.position = new Vector2(41f, 5.4f);
                }
                else if (currentScene == "Win")
                {
                    player.position = new Vector2(10.52f, 3.43f);
                }
                else if (currentScene == "Death")
                {
                    player.position = new Vector2(11.09f, 2.12f);
                }
                break;
            case "Theforest_02":
                if (currentScene == "Theforest_01")
                {
                    player.position = new Vector2(5f, -10f);

                }
                else if (currentScene == "Thebeach")
                {
                    player.position = new Vector2(10f, 22f);
                }
                else if (currentScene == "TheTown_01")
                {
                    player.position = new Vector2(-14f, 0f);
                }
                else if (currentScene == "Win")
                {
                    player.position = new Vector2(10.52f, 3.43f);
                }
                else if (currentScene == "Death")
                {
                    player.position = new Vector2(11.09f, 2.12f);
                }
                break;
            case "Shed":
                switch (currentScene)
                {
                    case "Starting_area":
                        player.position = new Vector2(14.6f, 1.24f);
                        break;
                    case "Win":
                        player.position = new Vector2(10.52f, 3.43f);
                        break;
                    case "Death":
                        player.position = new Vector2(11.09f, 2.12f);
                        break;
                }
                break;

        }

    }

    public void Update()
    {
        if (!musicStarted)
        {
            musicStarted = true;
            AudioManager.instance.PlayMusic(musicToPlay);
        }
    }
}
