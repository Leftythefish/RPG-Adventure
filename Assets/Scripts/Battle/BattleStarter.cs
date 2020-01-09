using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public Player player;
    public BattleType[] potentialBattles;
    public CharStats charStats;
    public bool activateOnEnter, activateOnStay, activateOnExit;
    private bool inArea;
    public bool deactivateAfterStarting;
    public float timeBetweenBattles = 10f;
    private float betweenBattleCounter;
    public string npcName;

    // Start is called before the first frame update
    void Start()
    {

        betweenBattleCounter = Random.Range(timeBetweenBattles * 0.5f, timeBetweenBattles * 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                betweenBattleCounter -= Time.deltaTime;
            }
            if (betweenBattleCounter <= 0)
            {
                betweenBattleCounter = Random.Range(timeBetweenBattles * 0.5f, timeBetweenBattles * 1.5f);
                StartCoroutine(StartBattleCo());
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateOnEnter)
            {
                StartCoroutine(StartBattleCo());
            }
            else
            {
                inArea = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateOnExit)
            {
                StartCoroutine(StartBattleCo());
            }
            else
            {
                inArea = false;
            }
        }
    }

    public IEnumerator StartBattleCo() //add fade in to battle
    {
        int selectedBattle = Random.Range(0, potentialBattles.Length);
        //UIfade.instamce.FadeToBlack();
        GameManager.instance.battleActive = true;

        yield return new WaitForSeconds(.000001f);

        //NPC npc = FindObjectOfType<NPC>();
        BattleManager.instance.npcName = npcName;

        BattleManager.instance.BattleStart(potentialBattles[selectedBattle].enemies);

        if (deactivateAfterStarting)
        {

            gameObject.SetActive(false);
        }

    }
}
