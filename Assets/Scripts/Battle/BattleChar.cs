using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChar : MonoBehaviour
{
    public bool isPlayer; //boolean to check if player
    public string[] movesAvailable; //string array for different moves, attacks , magic, items... Slash, Fire attacks for now

    public string charName; //name
    public float currentHp, maxHp;
    public int currentMp, maxMp, strength, defence;/* weaponPower, armorPower;*/ //integer values for stats

    public bool hasDied; //bool value for dead/not dead

    public SpriteRenderer theSprite;
    public Sprite deadSprite;
    public Sprite aliveSprite;

    private bool shouldFade;
    public float fadeSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFade) ///vihu kuolee ja fadee pois näkyvistä punaisen kautta hyi
        {
            theSprite.color = new Color(Mathf.MoveTowards(theSprite.color.r, 1f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.g, 0f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.b, 0f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (theSprite.color.a == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void EnemyFade()
    {
        shouldFade = true;
    }
}
