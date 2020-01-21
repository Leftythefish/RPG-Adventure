using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stat : MonoBehaviour
{
    public static Stat instance;

    private Image content;

    //public Player player;

    [SerializeField]
    private float lerpSpeed;

    public float currentFill;

    public float currentValue;
    public float maxValue;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();

        if (instance != null)
        {
            //Debug.LogWarning("More than one instance of Stat found!");
            Destroy(instance);
            Destroy(instance.gameObject);
            //instance = this;
            //return;
        }

        instance = this;

        if (Player.instance != null)
        {
            maxValue = Player.instance.maxHealth;
            currentValue = Player.instance.currentHealth;
            currentFill = currentValue / maxValue;
            content.fillAmount = currentFill;
        }
    }

    // Update is called once per frame
    void Update()
    {
        maxValue = Player.instance.maxHealth;
        currentValue = Player.instance.currentHealth;
        currentFill = currentValue / maxValue;

        if (currentFill != content.fillAmount)
        {
            // lerp setting ensures the health doesnt change in blocks but moves gradually
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

    }

    //public void Initialize()
    //{
    //    maxValue = Player.instance.maxHealth;
    //    currentValue = Player.instance.currentHealth;
    //}
}
