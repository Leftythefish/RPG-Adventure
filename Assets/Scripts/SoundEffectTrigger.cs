using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectTrigger : MonoBehaviour
{
    public int soundToPlay;
    public AudioManager audioManager;
    public bool destroyWhenActivated;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject != null && audioManager != null)
            {
                audioManager.PlaySFX(soundToPlay);
                
                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
