using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public float effectLength; //how long effect will last
    //public int soundEffect; //add soundeffect
    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.instance.PlaySFC/soundEffect); play sound effect
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, effectLength);
    }
}
