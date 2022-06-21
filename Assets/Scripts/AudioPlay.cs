using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{

    public AudioSource One;
    public AudioSource Two;
    public AudioSource Three;
    public AudioSource Four;
    public AudioSource Five;
    public AudioSource Six;

    public void play (string clip)
    {
        if (clip == "1")
        {
            One.Play();
        }
        else if (clip == "2")
        {
            Two.Play();
        }
        else if (clip == "3")
        {
            Three.Play();
        }
        else if (clip == "4")
        {
            Four.Play();
        }
        else if (clip == "5")
        {
            Five.Play();
        }
        else if (clip == "6")
        {
            Six.Play();
        }
    }
}
