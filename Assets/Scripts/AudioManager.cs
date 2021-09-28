using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource splash;
    public AudioSource rocket;
    public AudioSource coin;
    public static AudioManager instance;

    void Awake()
    {
        if(instance == null) 
             instance = this;
    }
    public void SplashSound()
    {
         splash.Play();
    }

    public void RocketSound()
    {
         rocket.Play();
    }

    public void CoinSound()
    {
         coin.Play();
    }
}
