using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
///  Manage the Audio based On operation
/// </Summary>
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
    public void SplashSound()    // sound on sea drop
    {
         splash.Play();
    }

    public void RocketSound()     // sound on rocket fire button press
    {
         rocket.Play();
    }

    public void CoinSound()     // sound on coin touch
    {
         coin.Play();
    }
}
