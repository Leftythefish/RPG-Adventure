using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public InventoryUI inventoryUI;

    public GameObject BattleScene;  //control if scene is on or off, create reference for that
    public GameObject Camera;
    public GameObject uiButtonsHolder;
    public GameObject enemyAttackEffect;
    public DamageNumber damageNumber;
    public GameObject targetMenu;
    public BattleTargetButtons[] targetButtons;
    public GameObject magicMenu;
    public BattleMagicSelect[] magicButtons;
    public BattleMove[] movesList;
    public Transform[] playerPositions;//reference to all the positions we want to our player appear
    public Transform[] enemyPositions;//reference to all the positions we want to our enemies appear
    //when battle starts it puts the playerprefabs(players) to playerpositions and same on enemies.
    public BattleChar[] playerPrefabs;//create array of our battlechar. grab players, put em in player positions
    public BattleChar[] enemyPrefabs; //grab enemies, put em in enemy positions

    public List<BattleChar> activeBattlers = new List<BattleChar>();

    public bool battleActive; //keep track if battle active or not
    public int currentTurn;//we need current number of our turn, cycles trough active battlers.
    public bool turnWaiting;//waiting for our turn to end, input from player, enemy to do move.

    bool playerDead = false;

    public string npcName;

    GameObject obj;

    //GameObject restart;


    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.currentHealth <= 0)
        {
            StartCoroutine(EndBattleCo2());
            return;
        }
        if (battleActive)
        {
            if (turnWaiting)
            {
                //put players in scene. Only 1 player here
                for (int i = 0; i < playerPositions.Length; i++)
                {
                    //Put players in right positions on the battle
                    if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
                    {
                        // find player
                        for (int j = 0; j < playerPrefabs.Length; j++)
                        {
                            //add Stats for player in battle. Health, Strength, Defence, etc.
                            if (playerPrefabs[j].charName == GameManager.instance.playerStats[i].charName)
                                activeBattlers[i].currentHp = Player.instance.currentHealth;
                            activeBattlers[i].maxHp = Player.instance.maxHealth;
                        }
                    }
                }
                // if it is players turn,
                if (activeBattlers[currentTurn].isPlayer)
                {
                    //set buttons to be used
                    uiButtonsHolder.SetActive(true);
                }
                else
                {
                    uiButtonsHolder.SetActive(false);
                    //We call Coroutine EnemyMoveCo() where enemy attacks
                    StartCoroutine(EnemyMoveCo());
                }
            }
        }
    }

    //start battle   //this needs the name of enemies we want to spawn in battle.
    public void BattleStart(string[] enemiesToSpawn)
    {
        if (!battleActive)
        {
            //UIFade.instance.FadeToBlack();
            Player.instance.OffRunSpeed();
            Player.instance.MuteWalk();
            AudioManager.instance.PlayMusic(4);
            StartCoroutine(FadeAudio.StartFade(AudioManager.instance.music[4], 3, 0.2f)); //fade in battle music
                                                                                          //activating battlescene camera
            Camera.SetActive(true);
            //setting battleactive boolean true
            battleActive = true;
            //activating battlescene GameObject
            BattleScene.SetActive(true);

            //put players in scene. Only 1 player here
            for (int i = 0; i < playerPositions.Length; i++)
            {
                //Put players in right positions on the battle
                if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
                {
                    // find player
                    for (int j = 0; j < playerPrefabs.Length; j++)
                    {
                        //add Stats for player in battle. Health, Strength, Defence, etc.
                        if (playerPrefabs[j].charName == GameManager.instance.playerStats[i].charName)
                        {
                            BattleChar newPLayer = Instantiate(playerPrefabs[j], playerPositions[i].position, playerPositions[i].rotation);
                            newPLayer.transform.parent = playerPositions[i];
                            activeBattlers.Add(newPLayer); //adding to list
                            CharStats thePlayer = GameManager.instance.playerStats[i];
                            activeBattlers[i].currentHp = Player.instance.currentHealth;
                            activeBattlers[i].maxHp = Player.instance.maxHealth;
                            activeBattlers[i].currentMp = thePlayer.currentMp;
                            activeBattlers[i].maxMp = thePlayer.maxMp;
                            activeBattlers[i].strength = thePlayer.strength;
                            activeBattlers[i].defence = thePlayer.defence;
                        }
                    }
                }
                //UIFade.instance.FadeFromBlack();


            }
            //Spawn enemies to battlefield and on the right places.
            for (int i = 0; i < enemiesToSpawn.Length; i++)
            {
                if (enemiesToSpawn[i] != "")
                {
                    for (int j = 0; j < enemyPrefabs.Length; j++)
                    {
                        if (enemyPrefabs[j].charName == enemiesToSpawn[i])
                        {
                            BattleChar newEnemy = Instantiate(enemyPrefabs[j], enemyPositions[i].position, enemyPositions[i].rotation);
                            newEnemy.transform.parent = enemyPositions[i];
                            activeBattlers.Add(newEnemy);
                        }
                    }
                }
            }
            turnWaiting = true; //when we start the battle . turnWaiting should be true.
            currentTurn = 0; // or you could randomize who starts = Random.Range(0, activeBattlers.Count);
        }
    }
    public void NextTurn()
    {

        currentTurn++;
        if (currentTurn >= activeBattlers.Count)
        {
            currentTurn = 0;
        }
        turnWaiting = true;
        UpdateBattle();
    }
    public void UpdateBattle() // check dead enemies, dead players
    {
  

        bool allEnemiesDead = true;
        playerDead = true;

        for (int i = 0; i < activeBattlers.Count; i++)
        {
            if (activeBattlers[i].currentHp < 0 || activeBattlers[i].currentHp == 0)
            {
                activeBattlers[i].currentHp = 0;
                if (activeBattlers[i].isPlayer)
                {
                    activeBattlers[i].theSprite.sprite = activeBattlers[i].deadSprite;
                    StartCoroutine(EndBattleCo());
                }
                else
                {
                    activeBattlers[i].EnemyFade();
                }
            }

            else
            {
                if (activeBattlers[i].isPlayer)
                {
                    playerDead = false;
                    activeBattlers[i].theSprite.sprite = activeBattlers[i].aliveSprite;
                }
                else
                {
                    allEnemiesDead = false;
                }
            }
        }
        if (allEnemiesDead || playerDead) // if either ones are dead, end battle
        {
            StartCoroutine(EndBattleCo());
        }
        else
        {
            while (activeBattlers[currentTurn].currentHp == 0) // While loop ettei kuolleet saa vuoroa.
            {
                currentTurn++;
                if (currentTurn >= activeBattlers.Count)
                {
                    currentTurn = 0;
                }
            }
        }
    }
    //so enemies wont attack instantly we make EnemyMoveCo, Coroutine can happen outside of normal order outside unity
    //adds delay to enemy attacks
    public IEnumerator EnemyMoveCo()
    {
        turnWaiting = false;
        //me will wait
        yield return new WaitForSeconds(1.5f);
        EnemyAttack();
        if (!playerDead)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(0.4f);
        }
        NextTurn();
    }
    //function for enemy attacking
    public void EnemyAttack()
    {
        if (battleActive)
        {
            List<int> players = new List<int>();
            for (int i = 0; i < activeBattlers.Count; i++)
            {
                if (activeBattlers[i].isPlayer && activeBattlers[i].currentHp > 0) // Check if in the activeplayers position i is player and his/her Hp is not zero
                {
                    players.Add(i);
                }
            }
            int selectedTarget = players[Random.Range(0, players.Count)]; // select player position randomly. we got only 1 player so ... not needed here
            int selectAttack = Random.Range(0, activeBattlers[currentTurn].movesAvailable.Length); //randomly select attack from attack list
            int movePower = 0;
            for (int i = 0; i < movesList.Length; i++)
            {
                if (movesList[i].moveName == activeBattlers[currentTurn].movesAvailable[selectAttack])
                {
                    Instantiate(movesList[i].theEffect, activeBattlers[0].transform.position, activeBattlers[0].transform.rotation);
                    movePower = movesList[i].movePower;
                }
            }
            Instantiate(enemyAttackEffect, activeBattlers[currentTurn].transform.position, activeBattlers[selectedTarget].transform.rotation);
            DealDamage(selectedTarget, movePower);
        }
    }
    public void DealDamage(int target, int movePower)
    {
        float atkPwr = activeBattlers[currentTurn].strength;
        float defPwr = activeBattlers[target].defence;
        float damageCalc = (atkPwr / defPwr) * movePower * Random.Range(0.9f, 1.1f);
        float damageToGive = Mathf.Round(damageCalc);
        activeBattlers[target].currentHp -= damageToGive;
       
        if (activeBattlers[target].isPlayer)
        {
            if (Player.instance.currentHealth - damageToGive <= 0)
            {
                StartCoroutine(EndBattleCo());
                Player.instance.TakeDamage(damageToGive);
            }
            else
            {
                Player.instance.TakeDamage(damageToGive);
            }
        }

        Instantiate(damageNumber, activeBattlers[target].transform.position, activeBattlers[target].transform.rotation).SetDamage(damageToGive);
        
        if (Player.instance.currentHealth <= 0)
        {
            playerDead = true;
        }
    }
    public void PlayerAttack(string moveName, int selectedTarget)       //PLayer attacks roar
    {
        int movePower = 0;
        for (int i = 0; i < movesList.Length; i++)
        {
            if (movesList[i].moveName == moveName)
            {
                Instantiate(movesList[i].theEffect, activeBattlers[selectedTarget].transform.position, activeBattlers[selectedTarget].transform.rotation);
                movePower = movesList[i].movePower;
            }
        }
        Instantiate(enemyAttackEffect, activeBattlers[currentTurn].transform.position, activeBattlers[selectedTarget].transform.rotation);
        DealDamage(selectedTarget, movePower);
        uiButtonsHolder.SetActive(false);
        targetMenu.SetActive(false);
        NextTurn();
    }
    public void OpenTargetMenu(string moveName)
    {
        magicMenu.SetActive(false);
        targetMenu.SetActive(true);
        List<int> Enemies = new List<int>(); // make list of enemies to choose who to attack
        for (int i = 0; i < activeBattlers.Count; i++)
        {
            if (!activeBattlers[i].isPlayer)
            {
                Enemies.Add(i);
            }
        }
        for (int i = 0; i < targetButtons.Length; i++)
        {
            if (Enemies.Count > i && activeBattlers[Enemies[i]].currentHp > 0)
            {
                targetButtons[i].gameObject.SetActive(true);
                targetButtons[i].moveName = moveName;
                targetButtons[i].activeBattleTarget = Enemies[i];
                targetButtons[i].targetName.text = activeBattlers[Enemies[i]].charName;
            }
            else
            {
                targetButtons[i].gameObject.SetActive(false);
            }
        }
    }
    public void OpenMagicMenu()
    {
        targetMenu.SetActive(false);
        magicMenu.SetActive(true);
        for (int i = 0; i < magicButtons.Length; i++)
        {
            if (activeBattlers[currentTurn].movesAvailable.Length > i)
            {
                magicButtons[i].gameObject.SetActive(true);

                magicButtons[i].spellName = activeBattlers[currentTurn].movesAvailable[i];
                magicButtons[i].nameText.text = magicButtons[i].spellName;

                for (int j = 0; j < movesList.Length; j++)
                {
                    if (movesList[j].moveName == magicButtons[i].spellName)
                    {
                        magicButtons[i].spellCost = movesList[j].moveCost;
                        magicButtons[i].costText.text = magicButtons[i].spellCost.ToString();
                    }
                }
            }
            else
            {
                magicButtons[i].gameObject.SetActive(false);
            }
        }
    }
    public IEnumerator EndBattleCo()
    {
        //this makes the sound fade twice when going back to scene - which is not desireable
        //yield return new WaitForSeconds(1f);

        uiButtonsHolder.SetActive(false);
        targetMenu.SetActive(false);
        magicMenu.SetActive(false);
        battleActive = false;

        ////not needed, enemies get destroyed when they die
        //for (int i = 0; i < activeBattlers.Count; i++)
        //{
        //    if (!activeBattlers[i].isPlayer)
        //    {
        //        //for (int j = 0; j < GameManager.instance.playerStats.Length; j++)
        //        //{
        //        //    if (activeBattlers[i].charName == GameManager.instance.playerStats[i].charName)
        //        //    {
        //        //        GameManager.instance.playerStats[j].currentHp = activeBattlers[i].currentHp;
        //        //        GameManager.instance.playerStats[j].currentMp = activeBattlers[i].currentMp;
        //        //    }
        //        //}
        //        //Destroy battlers so no weird cloning happens
        //        Destroy(activeBattlers[i].gameObject);
        //    }
        //}

        if (!playerDead)
        {
            //fade battlemusic out
            StartCoroutine(FadeAudio.StartFade(AudioManager.instance.music[4], 3f, 0f));
            //UIFade.instance.FadeToBlack();
            yield return new WaitForSeconds(3f);
            //UIFade.instance.FadeFromBlack();
        }

        for (int i = 0; i < activeBattlers.Count; i++)
        {
            if (activeBattlers[i].isPlayer)
            {
                for (int j = 0; j < GameManager.instance.playerStats.Length; j++)
                {
                    if (activeBattlers[i].charName == GameManager.instance.playerStats[i].charName)
                    {
                        GameManager.instance.playerStats[j].currentHp = activeBattlers[i].currentHp;
                        GameManager.instance.playerStats[j].currentMp = activeBattlers[i].currentMp;
                    }
                }
            }
                Destroy(activeBattlers[i].gameObject);
        }

        //reset turn to 0 = player
        currentTurn = 0;
        GameManager.instance.battleActive = false;
        battleActive = false;
        Camera.SetActive(false);
        Player.instance.OnRunSpeed();
        EnemyDefeated ef = obj.AddComponent<EnemyDefeated>();
        ef.DetermineDefeated(npcName);

        // battlescene unactive
        BattleScene.SetActive(false);
        //Reset battler list
        activeBattlers.Clear();

        //find music from worldcontroller
        int sceneMusic = FindObjectOfType<WorldController>().musicToPlay;
        AudioManager.instance.music[sceneMusic].volume = 0f;
        AudioManager.instance.PlayMusic(sceneMusic);
        //if (!playerDead)
        //{
        //fade in music
        StartCoroutine(FadeAudio.StartFade(AudioManager.instance.music[sceneMusic], 3, 0.2f));
        //}
        Player.instance.UnMuteWalk();
    }
    public IEnumerator EndBattleCo2()
    {
        //this makes the sound fade twice when going back to scene - which is not desireable
        //yield return new WaitForSeconds(1f);

        uiButtonsHolder.SetActive(false);
        targetMenu.SetActive(false);
        magicMenu.SetActive(false);
        battleActive = false;
        if (!playerDead)
        {
            AudioManager.instance.music[4].volume = 0f;
            //StartCoroutine(FadeAudio.StartFade(AudioManager.instance.music[4], 1f, 0f));
            yield return null;
        }

        for (int i = 0; i < activeBattlers.Count; i++)
        {
            if (activeBattlers[i].isPlayer)
            {
                for (int j = 0; j < GameManager.instance.playerStats.Length; j++)
                {
                    if (activeBattlers[i].charName == GameManager.instance.playerStats[i].charName)
                    {
                        GameManager.instance.playerStats[j].currentHp = activeBattlers[i].currentHp;
                        GameManager.instance.playerStats[j].currentMp = activeBattlers[i].currentMp;
                    }
                }
            }
            Destroy(activeBattlers[i].gameObject);
        }
        currentTurn = 0;
        GameManager.instance.battleActive = false;
        battleActive = false;
        Camera.SetActive(false);
        Player.instance.OnRunSpeed();
        EnemyDefeated ef = obj.AddComponent<EnemyDefeated>();
        ef.DetermineDefeated(npcName);

        // battlescene unactive
        BattleScene.SetActive(false);
        //Reset battler list
        activeBattlers.Clear();

        //find music from worldcontroller
        int sceneMusic = FindObjectOfType<WorldController>().musicToPlay;
        AudioManager.instance.music[sceneMusic].volume = 0f;
        AudioManager.instance.PlayMusic(sceneMusic);
        StartCoroutine(FadeAudio.StartFade(AudioManager.instance.music[sceneMusic], 3, 0.2f));
        //}
        Player.instance.UnMuteWalk();
    }

}