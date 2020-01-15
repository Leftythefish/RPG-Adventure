using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{


    public Player player;

    //add some default variables, used thorought game
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel; //use this list to level up
    public int maxLevel = 100;
    public int baseEXP = 1000;
    public float currentHp;
    public float maxHp;
    public int[] mpLvlBonus; // we are making a bit different way of giving mp when player level ups, more work, more control
    public int currentMp;
    public int maxMp;
    public int strength;
    public int defence;
    //public int weaponPower;
    //public int armorPower;
    //public string equippedWeapon;
    //public string equippedArmor;
    public Sprite charImage;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        maxHp = player.maxHealth;
        currentHp = player.currentHealth;
        expToNextLevel = new int[maxLevel];
        //how much xp should happen to get level up
        expToNextLevel[1] = baseEXP; // first level = 1000xp
        //make for loop to set how much xp player needs to get to level up to next level
        //building experience list
        for (int i = 2; i < expToNextLevel.Length; i++) // set it to 2, because element 0 and 1 are already created on our expToNextLevel
        {
            //Debug.Log(i); // write to unity log, dev eyes only
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f); //chops off the decimals.//easily goes to overflow, minus values if you multiply too much
        }
    }
    #region Xp calculator.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(1000);
        }
    }
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        //check if level up
        if (playerLevel < maxLevel) // if so we are allowed to level up stuff :)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                //minus the needed exp to level up from your current exp.
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++; //plus playerLevel by 1;

                //determine wheter to add to strength or defence based on odd or even. meh meh meh..
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                player.maxHealth = Mathf.FloorToInt(maxHp * 1.05f);
                maxHp = player.maxHealth;

                //maxHp = Mathf.FloorToInt(maxHp * 1.05f);

                player.currentHealth = player.maxHealth;
                currentHp = maxHp; //when level up, currenthp to full.

                //adding mp
                //maxMp = maxMp + mpLvlBonus[playerLevel]; one way to do it, below is a bit shorter way.
                maxMp += mpLvlBonus[playerLevel]; //maximum mp plus equals maxMp and mpLvlBonus[playerLevel]. += shortens the code a bit
                currentMp = maxMp;
            }
        }
        if (playerLevel >= maxLevel) // you are max level, no more leveling up for you hot stuff!
        {
            currentEXP = 0;
        }
    }
    #endregion
}
