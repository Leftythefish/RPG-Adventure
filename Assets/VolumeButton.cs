using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeButton : MonoBehaviour
{
    public void AudioOn()
    {
        AudioManager.instance.AudioOn();
    }
    public void AudioOff()
    {
        AudioManager.instance.AudioOff();
    }
}
