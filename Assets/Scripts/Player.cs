using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField]
    float runSpeed = 5f;

    public float maxHealth;
    public float currentHealth;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Vector2 movement;
    AudioSource footsteps;

    public string playerName;

    public bool canMove;
    public bool speedBoost = false;
    public float effectTime;
    public float speedEffect;

    public static int timesStarted;

    GameObject restart;
    GameObject battleManager;

    void Start()
    {
        timesStarted++;

        if (instance != null)
        {
            //Debug.LogWarning("More than one instance of Player found!");

            currentHealth = instance.currentHealth;
            maxHealth = instance.maxHealth;
            canMove = instance.canMove;
            speedBoost = instance.speedBoost;
            effectTime = instance.effectTime;
            speedEffect = instance.speedEffect;
            runSpeed = instance.runSpeed;
            footsteps = instance.footsteps;

            Destroy(instance);
            Destroy(instance.gameObject);

            instance = this;
            //instance.canMove = this.canMove;
            //instance.maxHealth = this.maxHealth;
            //instance.currentHealth = this.currentHealth;
            //instance.speedBoost = this.speedBoost;
            //instance.effectTime = this.effectTime;
            //instance.speedEffect = this.speedEffect;
            //return;
        }

        //Destroy(this);
        //Destroy(this.gameObject);

        if (timesStarted <= 1)
        {
            instance = this;
            maxHealth = 100;
            currentHealth = 100;
        }

        GameObject.DontDestroyOnLoad(this);

        //healthbar.Initialize();

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        footsteps = gameObject.GetComponent<AudioSource>();
        var player = GameObject.Find("Player1");
        var playerPos = player.transform.position;

        if (Stat.instance != null)
        {
            Stat.instance.maxValue = maxHealth;
            Stat.instance.currentValue = currentHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Stat.instance.maxValue = maxHealth;
        Stat.instance.currentValue = currentHealth;
        Stat.instance.currentFill = currentHealth / maxHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            DeathSound();

            if (BattleManager.instance.battleActive)
            {
                return;
            }
            restart = GameObject.Find("Restart");
            Restart r = restart.AddComponent<Restart>();
            r.Death();
        }

        if (speedBoost)
        {
            effectTime -= Time.deltaTime;
            //Debug.Log(effectTime.ToString());

            if (effectTime <= 0f)
            {
                runSpeed -= speedEffect;
                speedBoost = false;
            }

        }

        GetInput(); //for input besides movement


        #region movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //controls the animation blend tree attributes to choose which movement animation to use
        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnimator.SetFloat("lastmove_x", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastmove_y", Input.GetAxisRaw("Vertical"));
        }
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            footsteps.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && footsteps.isPlaying)
        {
            footsteps.Stop(); // or Pause()
        }
        #endregion
    }

    private void GetInput()
    {
        //Debuggin part, to be removed
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    health.MyCurrentValue -= 10;
        //}
        if (Input.GetKeyDown(KeyCode.O))
        {
            currentHealth += 10;
        }
    }

    void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + movement * runSpeed * Time.fixedDeltaTime);
    }
    //jyri testailee, koska jyrillä paljon sekavaa koodia asiaan liittyen. Tällä voi miinustaa healttia
    public void SetHealth(float setHp)
    {
        currentHealth = setHp;
    }
    //jyri testailee, koska jyrillä paljon sekavaa koodia asiaan liittyen. Tällä voi lisätä Healttia
    public void TakeDamage(float a)
    {
        currentHealth -= a;
    }
    public void AddHealth(float a)
    {
        currentHealth += a;
    }
    public void SpeedBoost(float speed, float time)
    {
        if (!speedBoost)
        {
            runSpeed += speed;
        }

        speedBoost = true;
        effectTime += time;
        speedEffect = speed;
    }
    public void OffRunSpeed()
    {

        runSpeed = 0f;
    }
    public void OnRunSpeed()
    {
        if (speedBoost != true)
        {
            runSpeed = 5f;
        }
        else
        {
            runSpeed = 5f + speedEffect;
        }
    }

    public void GameOver()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    public void MuteWalk()
    {
        footsteps.mute = true;
    }
    public void UnMuteWalk() // not in use atm
    {
        footsteps.mute = false;
    }

    public void DeathSound()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlaySFX(22);
    }
}
