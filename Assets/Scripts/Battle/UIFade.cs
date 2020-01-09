using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using UI so we can use "Image" etc.
public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeScreen; //making variable for our image
    public float fadeSpeed; //variable for how fast it will fade to black, out of black
    public bool shouldFadeToBlack; //making variables for fading
    public bool shouldFadeFromBlack;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack) //we will increase alpha (a) value (transparency 0 - 255)
        {
            //not 255, in scripts its 1 or 0. //setting r-g-b values to be what they are on fadeScreen. Using mathf.movetowards which will move a value current towards target
            //using fadespeed * time.deltatime. So faster and slower computers will have same fade experience.
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0)
            {
                shouldFadeFromBlack = false;
            }
        }
    }
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
